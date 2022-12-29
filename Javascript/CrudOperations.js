let book=[]
//add Item
function addItem(item){
  book.push(item)
}
//display items
const getAll=()=>book; //lambda function

function deleteItems(index){
    book.splice(index,1);  //book.splice(index,0,"abcdef")
}
//or
//const delete=(index)=>book.splice(index,1);
function updateItems(index,item){
    book[index]=item;
}