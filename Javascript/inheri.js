const baseClass=class{
    data1=document.getElementById("txtName").value
    data2=document.getElementById("txtAge").value
    toString(){
        return `${this.data1} and ${this.data2}`
    }
}
class derivedClass extends baseClass{
data3="old"
toString(){
    let data=super.toString()
    data+=this.data3
    return data;
}
}

const data=new derivedClass();
const value = data.toString()
function display()
{
    const p=document.getElementById("pdisp")
    p.innerHTML=value
  
}