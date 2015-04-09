var module = (function () {
    // приватные переменная
    var listSelectorName = "#list";
    var firstSelectorName = "#first";
    var btnSelectorName = "#btn";
    //публичные переменные
    return {
        init: function() {
            $(function() {
                module.load();
            });
        },
        load: function() {
            alert();
            var elem = module.getElements();
            module.bindEvents(elem);
            module.createLi(elem);
            module.hideFirstLi(elem);
        },
        getElements: function() {
            var list = $(listSelectorName);
            var firstLi = $(firstSelectorName);
            var btn = $(btnSelectorName);
            var elem = {
                list: list,
                firstLi: firstLi,
                btn: btn
            };
            return elem;
        },
        bindEvents: function(elem) {
            elem.btn.click(function() {
                module.showFirstLi(elem);
            });
        },
        createLi: function(elem) {
            var li = $('<li />').text('Новый элемент списка').css('color', 'red');
            elem.list.append(li);
        },
        hideFirstLi: function(elem) {
            elem.firstLi.hide();
        },
        showFirstLi: function(elem) {
            elem.firstLi.show();
        }
    };
}());