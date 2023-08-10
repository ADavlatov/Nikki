function openItem() {
    console.log(event.target.target)
    console.log(event.target)
    console.log(event.target.className)
    if (event.target) {
        if (event.target.children.item(1).style.display === "none") {
            event.target.children.item(1).style.display = "unset";
            event.target.children.item(0).children.item(0).style.rotate = "270deg";
        } else {
            event.target.children.item(1).style.display = "none";
            event.target.children.item(0).children.item(0).style.rotate = "90deg";
        }
    }
}