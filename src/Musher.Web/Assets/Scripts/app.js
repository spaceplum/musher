(function (window, $) {

    var resizeTimer;

    function inputOutput() {
        $('.input-output').each(function() {
            var self = $(this),
                nodes = self.children(),
                input = $(nodes[0]),
                output = $(nodes[1]),
                reset = $(nodes[2]);
            input.val(output.val());
            input.on('input', function () {
                output.val(input.val());
            });
            reset.on('click', function() {
                input.val('');
                output.val('');
            });
        });
    };

    function select2() {
        $('.select2').select2({
            allowClear: true,
            dropdownAutoWidth: true,
            placeholder: ''
        });
    }

    function init() {
        select2();
        inputOutput();
    }

    $(init);
    $(window).resize(function () {
        window.clearTimeout(resizeTimer);
        resizeTimer = window.setTimeout(init, 250);
    });

})(window, jQuery);
