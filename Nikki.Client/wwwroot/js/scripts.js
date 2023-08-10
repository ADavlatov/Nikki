function openItem(id) {
    if (id.children.item(1).style.display === "none") {
        id.children.item(1).style.display = "unset";
        id.children.item(0).children.item(0).style.rotate = "270deg";
    } else {
        id.children.item(1).style.display = "none";
        id.children.item(0).children.item(0).style.rotate = "90deg";
    }
}