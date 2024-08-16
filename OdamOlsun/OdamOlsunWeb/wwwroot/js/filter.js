$(document).ready(function() {
    $('#searchButton').click(function() {
        var selectedIl = $('#il').val();
        var selectedIlce = $('#ilce').val();
        var selectedSemt = $('#semt').val();
        
        var query = '';
        
        if (selectedIl) {
            query += 'il=' + selectedIl;
        }
        if (selectedIlce) {
            if (query) query += '&';
            query += 'ilce=' + selectedIlce;
        }
        if (selectedSemt) {
            if (query) query += '&';
            query += 'semt=' + selectedSemt;
        }

        if (query) {
            window.location.href = '/Ilanlar?' + query;
        } else {
            window.location.href = '/Ilanlar';
        }
    });
});
