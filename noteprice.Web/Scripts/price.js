function toAdd() {
    $('#addPrice').show();
    $('#search').hide();
    $('#Text').val($('#filter').val());
}

function toSearch() {
    $('#search').show();
    $('#addPrice').hide();
}

function onSuccessPriceAdd() {
    $('#Text').val('');
    $('#ValueStr').val('');
    $('#WeightStr').val('');
    $('#filter').val('');
    toSearch();
}

function onFailureQuery() {
    alert('Sorry, something went wrong, please try later.');
}