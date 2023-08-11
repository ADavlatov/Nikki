function openItem(id) {
    if (id.children.item(1).style.display === "none") {
        id.children.item(1).style.display = "unset";
        id.children.item(0).children.item(0).style.rotate = "270deg";
    } else {
        id.children.item(1).style.display = "none";
        id.children.item(0).children.item(0).style.rotate = "90deg";
    }
}

function openSidebar(){
    let sidebar = document.getElementById("sidebar");
    let hiddenSidebar = document.getElementById("sidebar-hidden");

    if (hiddenSidebar.style.display === "grid"){
        hiddenSidebar.style.display = "none";
        sidebar.style.display = "block";
    } else {
        hiddenSidebar.style.display = "grid";
        sidebar.style.display = "none";
    }
}