$(document).ready(function () {
    var vm = {};

    // change date format to assign it to date input
    function setDate(date) {

        var actualDate = new Date(date);

        var day = actualDate.getDate(),
            month = actualDate.getMonth() + 1,
            year = actualDate.getFullYear();

        month = (month < 10 ? "0" : "") + month;
        day = (day < 10 ? "0" : "") + day;

        return year + "-" + month + "-" + day;
    }

    $.ajax({
        url: "/api/newrentals",
        method: "GET",
        success: function (result) {
            $("#LastIdentValue").val(result.lastIdentValue);
            $(".rent-date").val(setDate(Date.now()));
        }
    });


    // Movies Auto Complete
    var movies = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        prefetch: "/api/movies",
        remote: {
            url: '/api/movies?query=%QUERY',
            method: "GET",
            wildcard: '%QUERY'
        }
    });

    $('#movie').typeahead({
        minLength: 1,
        highlight: true
    }, {
        name: 'movies',
        display: 'name',
        source: movies
    }).on('typeahead:select', function (e, movie) {
        vm.movieID = movie.id;
    });


    // Customer Auto Complete
    var customers = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        prefetch: "/api/customers",
        remote: {
            url: '/api/customers?query=%QUERY',
            method: "GET",
            wildcard: '%QUERY'
        }
    });

    $('#customer').typeahead({
        minLength: 1,
        highlight: true
    }, {
        name: 'customer',
        display: 'name',
        source: customers
    }).on('typeahead:select', function (e, customer) {
        vm.customerID = customer.id;
    });


    // Adding movie to cart
    $(".btn-add-movie").on("click",
        function () {

            $(".shopping-cart").append(
                `
                        <div class="card"  data-price ="${$(".movie-price").val()}" data-quantity="${$(".movie-quantity").val()}"   style="width: 18rem;">
                            <div class="card-body">
                                <h5 class="card-title">${vm.movieID}</h5>
                                <h6 class="card-subtitle mb-2 text-muted">
                                    <strong>GENRE: </strong>${$(".select-movie option:selected").attr("data-genre")}
                                </h6>
                                <p class="card-text">
                                    <strong>Unit price: </strong>
                                    ${$(".movie-price").val()}

                                </p>
                                <p class="card-text">
                                    <strong>Quantity: </strong>
                                    ${$(".movie-quantity").val()}
                                </p>
                                <button class="btn btn-danger card-link btn-remove-from-cart">Remove From Cart</button>
                            </div>
                        </div>
    `);
            $('.select-customer').prop('disabled', true);
            $('.btn-confirm').prop('disabled', false);
        });

    // remove movie from cart
    $(".shopping-cart").on("click",
        ".btn-remove-from-cart",
        function () {
            console.log($(this).parents(".card"));
            $(this).parents(".card").remove();

            if ($(".shopping-cart").children().length === 0) {
                $('.select-customer').prop('disabled', false);
                $('.btn-confirm').prop('disabled', true);

            }
        });

    // Confirmation
    $('.btn-confirm').on('click',
        function () {

            let rentalDetails = [];

            for (let i = 0; i < $(".shopping-cart").children().length; i++) {
                rentalDetails.push({
                    "rentalID": parseInt($("#LastIdentValue").val()) + 1,
                    "movieID": $(".select-movie option:selected").val(),
                    "unitPrice": $(".shopping-cart").children()[i].getAttribute("data-price"),
                    "quantity": $(".shopping-cart").children()[i].getAttribute("data-quantity")
                });
            }

            const data = {
                "customerID": vm.customerID,
                "employeeID": $(".employee").attr('data-id'),
                "rentDate": $('.rent-date').val(),
                "rentalDetails": rentalDetails
            };

            $.ajax({
                url: '/api/newrentals',
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(data),
                success: function () {
                    console.log("Order confirmed");
                }
            });

        });

});