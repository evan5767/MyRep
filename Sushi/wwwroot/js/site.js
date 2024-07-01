$(document).ready(function () {
    $('.add-to-cart').on('click', function () {
        var id = $(this).data('id');
        var showDiv = $('#show-' + id);
        /*var showDiv = $(this).siblings('.show[data-id="' + id + '"]');*/
        $.ajax({
            url: '/ShopCart/addToCart',
            type: 'POST',
            data: { id: id },
            success: function (response) {
                showDiv.html(response);
                showDiv.append('<div class="alert alert-success mt-2">Товар добавлен в корзину!</div>');
            },
            error: function (xhr, status, error) {
                console.error('Error: ' + error);
            }
        });
    });
});