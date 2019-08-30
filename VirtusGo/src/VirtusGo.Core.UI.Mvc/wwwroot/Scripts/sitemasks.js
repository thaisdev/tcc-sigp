var SPMaskBehavior = function (val) {
        return val.replace(/\D/g, '').length === 9 ? '00000-0000' : '0000-00009';
    },
    spOptions = {
        onKeyPress: function (val, e, field, options) {
            field.mask(SPMaskBehavior.apply({}, arguments), options);
        }
    };

$('.fonemask').mask(SPMaskBehavior, spOptions);