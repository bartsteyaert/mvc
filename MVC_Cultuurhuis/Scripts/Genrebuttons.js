function toggleClass(el) {
    //alle genre op 'niet actief' zetten
    var ulElement = el.parentElement;
    var ilElementen = ulElement.children;
    var i;
    for (i = 0; i < ilElementen.length; i++) {
        ilElementen[i].className = "";
    }
    //het gekozen genre op 'actief' zetten
    el.className = "active";

    //mededeling "kies genre" verwijderen na eerste keuze genre
    var mededeling = document.getElementById("kiesgenre");
    mededeling.style.display = "none";
}