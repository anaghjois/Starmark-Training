const saveToLocal=(key,val)=>{
    if(!localStorage){
        alert("nothing in storage")
        return;
    }
    localStorage.setItem(key,val)
}

const viewData=()=>{
    const key=document.getElementById('txtNum').value
    if(!localStorage){
        alert("No data to Show")
    }
    document.getElementById("pDisplay").innerText=localStorage.getItem(key)
}