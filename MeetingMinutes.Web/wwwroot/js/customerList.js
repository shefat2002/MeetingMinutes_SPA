$(document).ready(function () {
    $('input[name="customerType"]').change(function () {
        var selectedType = $(this).val();
        loadCustomers(selectedType);
    });

    function loadCustomers(customerType) {
        // Show loading indicator
        $('#loadingIndicator').show();

        $('#customerDropdown').html('<option value="">-- Loading... --</option>');

        // Make AJAX call to get customers
        $.ajax({
            url: '/Home/GetCustomers',
            type: 'GET',
            data: { customerType: customerType },
            success: function (data) {
                $('#customerDropdown').empty();

                $('#customerDropdown').append('<option value="">-- Select a customer --</option>');

                // Add customer options
                if (data && data.length > 0) {
                    $.each(data, function (index, customer) {
                        $('#customerDropdown').append(
                            '<option value="' + customer.value + '">' + customer.text + '</option>'
                        );
                    });
                } else {
                    $('#customerDropdown').append('<option value="">-- No customers found --</option>');
                }

                // Hide loading indicator
                $('#loadingIndicator').hide();
            },
            error: function (xhr, status, error) {
                console.error('Error loading customers:', error);

                // Clear dropdown and show error
                $('#customerDropdown').empty();
                $('#customerDropdown').append('<option value="">-- Error loading customers --</option>');

                // Hide loading indicator
                $('#loadingIndicator').hide();

                // Show error message (optional)
                alert('Error loading customers. Please try again.');
            }
        });
    }
});

