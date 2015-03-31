$(function () {
    var client = $.connection.imHub;

    client.client.Send = function (nick, message) {
        $('#chat').append("<div><b>" + nick + "</b>: " + message + "</div>");
    };

    $.connection.hub.start().done(function () {
        $('#sendmessage').click(function () {
            var mess = $('#textval').val();
            var nick = $('#nickval').val();
            client.server.send(nick, mess);
            $('#textval').val("");
        });
    });
});