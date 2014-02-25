

var CERP = window.CERP || {};

PM.Services = PM.Services || {};
PM.Services.AjaxGetCall = function (fullUrl, callbackFunction) {
    $.ajax({
        url: fullUrl,
        cache: false,
        success: function (data) { callbackFunction(PM.Utils.GetJson(data)); },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("error :" + XMLHttpRequest.responseText);
            alert('There was an error in performing this operation.');
        }
    });
};
PM.Services.AjaxPostCall = function (fullUrl, dataObj, callbackFunction) {
    $.ajax({
        url: fullUrl,
        cache: false,
        type: 'post',
        data : dataObj,
        success: function (data) { callbackFunction(PM.Utils.GetJson(data)); },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("error :" + XMLHttpRequest.responseText);
            alert('There was an error in performing this operation.');
        }
    });
};
PM.Services.AjaxJsonPostCall = function (fullUrl, dataObj, callbackFunction) {
    $.ajax({
        type: 'post',
        url: fullUrl,
        data: JSON.stringify(dataObj),
        dataType: 'json',
        cache: false,
        success: function (data) { callbackFunction(PM.Utils.GetJson(data)); },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("error :" + XMLHttpRequest.responseText);
            alert('There was an error in performing this operation.');
        }
    });
};



PM.Services.NumericObservable = function (initialValue) {
    var _actual = ko.observable(initialValue);

    var result = ko.dependentObservable({
        read: function () {
            return _actual();
        },
        write: function (newValue) {
            var parsedValue = parseFloat(newValue);
            _actual(isNaN(parsedValue) ? newValue : parsedValue);
        }
    });

    return result;
};



PM.DataGridAjax = (function () {
    var getDataUrl = '';
    function DataGridAjax(url, size) {
        var self = this;
        getDataUrl = url;
        self.GridParams = {
            number: ko.observable(1),
            size: ko.observable(size),
            sortField: ko.observable(''),
            sortOrder: ko.observable('ASC'),
            totalElements: ko.observable(0),
            totalPages: ko.observable(0),
            requestedPage: ko.observable(0),
            pageSizeOptions: [1,5, 10, 20, 30, 50, 100]
        };
        self.PageSlide = ko.observable(2); //PM.Services.NumericObservable(2);
        self.DataRows = ko.observableArray();
        self.Pages = ko.observableArray();
        self.SelectedPageSizeOption = ko.observable(size);
        self.GridParams.requestedPage.subscribe(self.FlipPageDirect, self);
        self.SelectedPageSizeOption.subscribe(self.Changesize, self);
        self.FirstItemIndex = function () { 
        	return self.GridParams.size() * (self.GridParams.number() - 1) + 1;
        };
        self.LastItemIndex = function () { 
        	return Math.min(self.FirstItemIndex() + self.GridParams.size() - 1, self.GridParams.totalElements());
        };
        self.SlidePages = ko.computed(function () {
            var pageCount = self.GridParams.totalPages();
            var pageFrom = Math.max(1, self.GridParams.number() - self.PageSlide());
            var pageTo = Math.min(pageCount, self.GridParams.number() + self.PageSlide());
            pageFrom = Math.max(1, Math.min(pageTo - 2 * self.PageSlide(), pageFrom));
            pageTo = Math.min(pageCount, Math.max(pageFrom + 2 * self.PageSlide(), pageTo));
            
           // console.log("pageCount:"+ pageCount +",currentPage:"+ self.GridParams.number() + ",pageForm:"+ pageFrom + ",pageTo:"+ pageTo);

            var result = [];
            for (var i = pageFrom; i <= pageTo; i++) {
                result.push(i);
            }
            return result;
        });
    }

    DataGridAjax.prototype.LastItemIndex  = function () { 
    	return Math.min(self.FirstItemIndex() + self.GridParams.size() - 1, self.GridParams.totalElements());
    };
    DataGridAjax.prototype.GetData = function () {
        var self = this;
        PM.Services.AjaxPostCall(getDataUrl, self.GridParams, $.proxy(self.OnGetDataDone, this));
    };
    DataGridAjax.prototype.OnGetDataDone = function (data) {
        var self = this;
        self.DataRows(PM.Utils.GetJson(data.content));
        self.GridParams.totalElements(PM.Utils.GetJson(data.totalElements));
        var totalPages = Math.ceil(self.GridParams.totalElements() / self.GridParams.size());
        self.GridParams.totalPages(totalPages);
        self.GridParams.requestedPage(self.GridParams.number());
        self.Pages =self.SlidePages();
    };
    DataGridAjax.prototype.FlipPage = function (newPageNo) {
        var self = this;
        if (parseInt(newPageNo) > 0 && parseInt(newPageNo) <= self.GridParams.totalPages()) {
            self.GridParams.number(newPageNo);
            self.GetData();
            self.Pages = self.SlidePages();
            console.log(self.Pages);
        }
    };
    DataGridAjax.prototype.FlipPageDirect = function (newValue) {
        var self = this;
        var ri = parseInt(self.GridParams.requestedPage());
        if ( ri == NaN) {
            self.GridParams.requestedPage(self.GridParams.number());
            return;
        }
        if (ri > 0 && ri <= self.GridParams.totalPages()) {
            self.GridParams.number(ri);
            self.GetData();
            return;
        }
        self.GridParams.requestedPage(self.GridParams.number());
        return;
    };
    DataGridAjax.prototype.Changesize = function () {
        var self = this;
        if (self.GridParams.size() != self.SelectedPageSizeOption()) {
            self.GridParams.size(self.SelectedPageSizeOption());
            self.GridParams.number(1);
            self.GridParams.requestedPage(1);
            self.GetData();
        }
    };
    DataGridAjax.prototype.Sort = function (col) {
        var self = this;
        if (self.GridParams.sortField() === col) {
            if (self.GridParams.sortOrder() === 'ASC') {
                self.GridParams.sortOrder('DESC');
            } else {
                self.GridParams.sortOrder('ASC');
            }
        } else {
            self.GridParams.sortOrder('ASC');
            self.GridParams.sortField(col);
        }
        self.GetData();
    };
    return DataGridAjax;
})();

PM.DataGridBasic = (function () {
    var getDataUrl = '';
    var allDataRows = new Array();
    function DataGridBasic(url, size) {
        var self = this;
        getDataUrl = url;
        self.GridParams = {
            number: ko.observable(1),
            size: ko.observable(size),
            sortField: ko.observable(''),
            sortOrder: ko.observable('ASC'),
            totalElements: ko.observable(0),
            totalPages: ko.observable(0),
            requestedPage: ko.observable(0),
            pageSizeOptions: [1,5, 10, 20, 30, 50, 100]
        };
        self.DataRows = ko.observableArray();
        self.SelectedPageSizeOption = ko.observable(size);
        self.GridParams.requestedPage.subscribe(self.FlipPageDirect, self);
        self.SelectedPageSizeOption.subscribe(self.Changesize, self);
    }
    DataGridBasic.prototype.GetData = function () {
        var self = this;
        PM.Services.AjaxPostCall(getDataUrl, '', $.proxy(self.OnGetDataDone, this));
    };
    DataGridBasic.prototype.OnGetDataDone = function (data) {
        var self = this;
        allDataRows = PM.Utils.GetJson(data.content);
        self.GridParams.totalElements(PM.Utils.GetJson(data.totalElements));
        self.UpdateData();
    };
    DataGridBasic.prototype.UpdateData = function () {
        var self = this;
        self.DataRows(self.GetPagedData());
        var totalPages = Math.ceil(self.GridParams.totalElements() / self.GridParams.size());
        self.GridParams.totalPages(totalPages);
        self.GridParams.requestedPage(self.GridParams.number());
    };
    DataGridBasic.prototype.FlipPage = function (newPageNo) {
        var self = this;
        if (parseInt(newPageNo) > 0 && parseInt(newPageNo) <= self.GridParams.totalPages()) {
            self.GridParams.number(newPageNo);
            self.UpdateData();
        }
    };
    DataGridBasic.prototype.FlipPageDirect = function (newValue) {
        var self = this;
        var ri = parseInt(self.GridParams.requestedPage());
        if (ri == NaN) {
            self.GridParams.requestedPage(self.GridParams.number());
            return;
        }
        if (ri > 0 && ri <= self.GridParams.totalPages()) {
            self.GridParams.number(ri);
            self.UpdateData();
            return;
        }
        self.GridParams.requestedPage(self.GridParams.number());
        return;
    };
    DataGridBasic.prototype.Changesize = function () {
        var self = this;
        if (self.GridParams.size() != self.SelectedPageSizeOption()) {
            self.GridParams.size(self.SelectedPageSizeOption());
            self.GridParams.number(1);
            self.GridParams.requestedPage(1);
            self.UpdateData();
        }
    };
    DataGridBasic.prototype.Sort = function (col) {
        var self = this;
        if (self.GridParams.sortField() === col) {
            if (self.GridParams.sortOrder() === 'ASC') {
                self.GridParams.sortOrder('DESC');
            } else {
                self.GridParams.sortOrder('ASC');
            }
        } else {
            self.GridParams.sortOrder('ASC');
            self.GridParams.sortField(col);
        }
        allDataRows.sort(self.dynamicSort(self.GridParams.sortField(), self.GridParams.sortOrder()));
        self.UpdateData();
    };
    DataGridBasic.prototype.GetPagedData = function() {
        var self = this;
        var size = self.GridParams.size();
        var start = (self.GridParams.number()-1)*size;
        return allDataRows.slice(start, start + size);
    };
    DataGridBasic.prototype.dynamicSort = function (sortProperty, direction) {
        debugger;
        var thisMethod = function(a, b) {
            var valueA = a[sortProperty];
            var valueB = b[sortProperty];
            if (typeof valueA != "number" && typeof valueA != "object") {
                valueA = a[sortProperty].toLowerCase();
                valueB = b[sortProperty].toLowerCase();
            }
            if (direction.toLowerCase() == "asc") {
                if (valueA < valueB) {
                    return -1;
                }
                if (valueA > valueB) {
                    return 1;
                }
            } else {
                if (valueA > valueB) {
                    return -1;
                }
                if (valueA < valueB) {
                    return 1;
                }
            }
            return 0;
        };
        return thisMethod;
    };

    return DataGridBasic;
})();


PM.Utils = PM.Utils || {};
PM.Utils.GetJson = function (data) {
    if (data == '' || data == 'undefined') return null;
    //return (JSON && JSON.parse(data) || $.parseJSON(data));
    return data;
};