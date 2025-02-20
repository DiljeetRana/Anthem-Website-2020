(function ($) {
    function HomeIndex() {
        var $this = this;

        function initialize() {
            $('#ContentPlaceHolder_txtDescription').summernote({
                focus: true,
                height: 150,
                codemirror: {
                    theme: 'united'
                }
            });
            $('#ContentPlaceHolder_txtVacancyContent').summernote({
                focus: true,
                height: 150,
                width:'98%',
                codemirror: {
                    theme: 'united'
                }
            });
        }

        $this.init = function () {
            initialize();
        }
    }
    $(function () {
        var self = new HomeIndex();
        self.init();
    })
}(jQuery))