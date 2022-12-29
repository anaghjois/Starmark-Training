const fs=require("fs")
const url="./EX-01.js"

function readSynchronous(){
    const content=fs.readFileSync(url,"utf-8") //synchronous
    console.log(content)
}
function readAsynchromous(){
    const fileData=fs.readFile(url,"utf-8",function (err,data) {
        if(err){
            console.error(err)
        }
        else{
            console.log(data)
        }
    })
    console.log("<<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>>")
    console.log("I execute first")
}
const Emp={id:"1",name:"Anagha"}
function writeFile(){
    fs.writeFileSync("Sample.txt",JSON.stringify(Emp),"utf-8")
    fs.appendFileSync("Sample.txt","\nI am Idris\n","utf-8")
    fs.appendFile("Sample.txt","\nHello Wassup Bois\n","utf-8",(err)=>{
        if(err)console.log(err)
    })
}
writeFile()
