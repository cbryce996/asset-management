/*------------------------------------------------------------------
* Bootstrap Simple Admin Template
* Version: 3.0
* Author: Alexis Luna
* Website: https://github.com/alexis-luna/bootstrap-simple-admin-template
-------------------------------------------------------------------*/
$(document).ready(function () {
    // Toggle sidebar on Menu button click
    $('#sidebarCollapse').click(function() {
        $('#sidebar').toggleClass('active');
        $('#body').toggleClass('active');
    });

    // Auto-hide sidebar on window resize if window size is small
    $(window).on('resize', function () {
        if ($(window).width() <= 900) {
            $('#sidebar, #body').addClass('active');
        }
    });
});

