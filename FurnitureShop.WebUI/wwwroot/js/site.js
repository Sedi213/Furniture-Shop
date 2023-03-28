// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


<script>
    function RedirectToFurniturePage(id) {
        window.location.href = window.location.protocol + "//" + window.location.host + "/" + "Views/FurniturePage?id=" + id
    }
</script>