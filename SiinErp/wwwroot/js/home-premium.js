function fnMessenger(message, type) {
    $(function () {
        Messenger.options = {
            extraClasses: 'messenger-fixed messenger-on-bottom  messenger-on-center',
            theme: 'flat',
            messageDefaults: {
                showCloseButton: true
            }
        }
        Messenger().post({
            message: message,
            type: type
        });
    });
}