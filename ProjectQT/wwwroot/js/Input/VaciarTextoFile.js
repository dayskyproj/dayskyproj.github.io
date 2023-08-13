

export async function VaciarInputFile(id) {
    setTimeout(function () {
        var input = document.querySelector("#" + id);
        if (input) {
            input.value = "";
        }
    }, 30);

}







