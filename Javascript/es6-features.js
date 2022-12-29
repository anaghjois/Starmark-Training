//let keyword and const keyword

var example=123
let example1=345
console.log(example)
console.log(example1)
for(var i=0;i<5;i++){
    //console.log(i)
}
console.log(i)

function sample(msg="Hi"){
    console.log(msg)
}
sample()
sample("hello boss")

const createDiv=(height="350px",width="200px",display="inline-block",border="2px dotted black")=>{
    const div=document.createElement("div")
    div.style.height=height;
    div.style.width=width;
    div.style.display=display;
    div.style.border=border;

    document.body.appendChild(div)
    return div

}
/////////REST
const add=(...args)=>{
    // let val=0;
    // for (const res of args) {
    //     val+=res;
    // }
    return args.filter((e)=>typeof e ==='number').reduce((pre,next)=>pre+next)
    
}

console.log(add(1,2))

console.log(add(1,2,4))

console.log(add(1,2,6,7,8))

console.log(add(1,2,"AA",'Anagha',{"data":123}))
////////Spread
const data=[1,2,34,4]
const newData=[0,1,234,214,...data]
console.log(newData)

const house=['Red',10000,"Lamborgini"]
const house2=["black","idris"]
const house3=[...house,...house2]
console.log(house3)


////static 

class addMethod{
 
   static add=(a,b)=>a+b
   callAdd(){
    this.constructor.add(3,4)
   }
}

console.log(addMethod.add(1,2))
const obj=new addMethod();
obj.callAdd()

///date

