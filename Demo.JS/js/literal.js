var literal = {
    init: function () {
        $(function() {
            literal.load();
        });
    },
    load: function() {
        alert();
        var elem = literal.getElements();
        literal.bindEvents(elem);
        literal.createLi(elem);
        literal.hideFirstLi(elem);
    },
    getElements: function () {
        var list = $('#list');
        var firstLi = $('#first');
        var btn = $('#btn');
        var elem = {
            list: list,
            firstLi: firstLi,
            btn: btn
        };
        return elem;
    },
    bindEvents: function (elem) {
        elem.btn.click(function() {
            literal.showFirstLi(elem);
        });
    },
    createLi: function (elem) {
        var li = $('<li />').text('Новый элемент списка').css('color', 'red');
        elem.list.append(li);
    },
    hideFirstLi: function (elem) {
        elem.firstLi.hide();
    },
    showFirstLi: function(elem) {
        elem.firstLi.show();
    }
};