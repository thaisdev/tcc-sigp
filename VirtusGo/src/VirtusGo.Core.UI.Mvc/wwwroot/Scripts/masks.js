$(".cepMask").mask("99999-999");

$('.telMask').each(function(i, el) {
    $('#' + el.id).mask("00000-0000");
});

$('.DddMask').each(function (i, el) {
    $('#' + el.id).mask("(15)");
});

$('.dataMask').each(function (i, el) {
    $('#' + el.id).mask("00/00/0000");
});

function updateMask(event) {
    var $element = $('#' + this.id);
    $(this).off('blur');
    $element.unmask();
    if (this.value.replace(/\D/g, '').length > 10) {
        $element.mask("00000-0000");
    } else {
        $element.mask("0000-00009");
    }
    $(this).on('blur', updateMask);
}
$('.telMask').on('blur', updateMask);

$(".rg").mask("99.999.999-9");

$(".cpfcnpj").keydown(function () {
    try {
        $(".cpfcnpj").unmask();
    } catch (e) { }

    var tamanho = $(".cpfcnpj").val().length;

    if (tamanho < 11) {
        $(".cpfcnpj").mask("999.999.999-99");
    } else if (tamanho >= 11) {
        $(".cpfcnpj").mask("99.999.999/9999-99");
    }

    // ajustando foco
    var elem = this;
    setTimeout(function () {
        // mudo a posição do seletor
        elem.selectionStart = elem.selectionEnd = 10000;
    }, 0);
    // reaplico o valor para mudar o foco
    var currentValue = $(this).val();
    $(this).val('');
    $(this).val(currentValue);
});

//$(".hibridCpf").on('focusin', function () {
//    var target = $(this);
//    var val = target.val();
//    target.unmask();
//    val = val.split(".").join("");
//    val = val.split("-").join("");
//    val = val.split("/").join("");
//    target.val(val);
//});
//$(".hibridCpf").on('focusout', function () {
//    var target = $(this);
//    var val = target.val();
//    val = val.split(".").join("");
//    val = val.split("-").join("");
//    val = val.split("/").join("");
//    if (val.length === 11) {
//        target.mask("999.999.999-99");
//        target.val(val);
//    } else {
//        if (val.length === 14) {
//            target.mask("99.999.999/9999-99");
//            target.val(val);
//        } else {
//            target.val('');
//        }
//    }
//});