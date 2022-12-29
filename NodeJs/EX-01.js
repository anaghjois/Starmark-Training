const addFunc=(a,b)=> a+b
console.log("The value is"+addFunc(1,2))
const data=[
    {id:"001",name:"Anagha",address:"Sagara"},
    {id:"002",name:"Gagan",address:"Davanagere"},
    {id:"003",name:"Goutham",address:"Sagara"},
    {id:"004",name:"Hanumanth",address:"Gulbarga"},
    {id:"005",name:"Phani",address:"Bengaluru"}
]
console.table(data)

const view=require("./CustModule")

view.simpleFunc()
view.mulFunc(10)
const emp=new view.myClass(1,"Anagha",1222)
emp.display()