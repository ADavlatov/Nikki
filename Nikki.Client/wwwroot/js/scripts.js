function openSidebarItem(id) {
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

function openMenu(id){

    if (id.style.display === "none") {
        id.style.display = "unset";
    } else {
        id.style.display = "none";
    }
}

function openItem(id){
    if (id.style.display === "grid"){
        id.style.display = "none"
    } else {
        id.style.display = "grid"
    }
}

function closeItem(id){
    id.style.display = "none"
}

// document.addEventListener('click', function(event) {
//     console.log("qweqweq")
//     var popup = document.querySelectorAll('.popup');
//     var button = document.querySelectorAll('.open-popup');
//
//     for (let i = 0; i < popup.length; i++){
//         for (let j = 0; j < button.length; j++){
//             if (event.target !== popup[i] && event.target !== button[j]) {
//                 popup[i].style.display = 'none';
//             }
//         }
//     }
// });
