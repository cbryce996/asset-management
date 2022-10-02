/*------------------------------------------------------------------
* Bootstrap Simple Admin Template
* Version: 3.0
* Author: Alexis Luna
* Website: https://github.com/alexis-luna/bootstrap-simple-admin-template
-------------------------------------------------------------------*/
alert('Testing Simple Admin Template');

$(document).ready(function () {
    alert('Loaded JQuery');
    // Toggle sidebar on Menu button click
    $('#sidebarCollapse').click(function() {
        alert('Click');
        $('#sidebar').toggleClass('active');
        $('#body').toggleClass('active');
    });
});

