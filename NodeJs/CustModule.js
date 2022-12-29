module.exports.simpleFunc=function(){
    console.log("Im new Export")
}

module.exports.mulFunc=function(num){
    console.log(`The Multiplication is ${num}`)
    for(let i=1;i<=10;i++){
        console.log(`${num}X${i}=${num*i}`)
    }
    console.log("-------------------------")
}
module.exports.myClass=class{
    constructor(id,name,sal){
    this.id=id
    this.name=name
    this.sal=sal
}
display(){
    console.log(`${this.id}'s name is ${this.name}`)
}
}
