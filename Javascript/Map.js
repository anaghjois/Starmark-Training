let data=new Map();
let msg=""
function signUp(uname,pwd){
    if(data.has(uname)){
        throw "User already exist"
    }
    data.set(uname,pwd)
    const success="Registered"
    return success
}
function signIn(uname,pwd){
    if(!data.has(uname)){
        throw "User doesn't exist"
    }else{
        const success="Logged Successfully"
        const failure="Passwor Failed"
        return ((data.get(uname)==pwd)? success:failure);
    }
}
//button

function onLogin(){
    const uname=document.getElementById("txtLogin").value
    const pwd=document.getElementById("txtPwd").value
    try{
        msg=signIn(uname,pwd)
    }catch(ex){
        msg=ex;
    }finally{
        clearFields();
    }
    document.getElementById("pMsg").innerText=msg;
}
//for Clearing fields
function clearFields(){
    let fields = document.getElementsByTagName("input");
    for(let i =0; i < fields.length; i++){
        fields[i].value = ""
    }
}
//user registration
function registerUser(){
    const uname = document.getElementById("txtNewUser").value;
    const pwd = document.getElementById("txtNewPwd").value;
    try{
        msg = signUp(uname, pwd)
    }catch(ex){
        msg = ex;
    }finally{
        clearFields();
    }
    document.getElementById("pMsg").innerText = msg;
}


