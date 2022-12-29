//Calculator

function onClick(){
    const first=parseFloat(document.getElementById("txtFirst").value);
    if(Number.isNaN(first)){
        alert("Not a Number");
    return;
    }
    const second=parseFloat(document.getElementById("txtSecond").value);
    const operator=document.getElementById("Operator").value;
    let result=0.0;
    switch(operator){
        case "+":
            result=first+second;
            break;
        case "-":
            result=first-second;
            break;
        case "*":
            result=first*second;
            break;
        case "/":
            result=first/second;
            break;            
    }
    document.getElementById("res").innerText=result;
    
}
//Convert Temperature

function conTemp(cel)
{
    let res=((9/5)*cel)+32;
    alert("The converted Temp :" +res);
}

//Favourite Book

function fvBook(){
    let book=[];
    const ol=document.getElementById("lstItems");
    book.push(document.getElementById("favBook").value);
    for(const item of book){
        const value="<li>"+item+"</li>"
        ol.innerHTML+=value;

    }
}

//currency convertor

function conCurrency(fromCountry,toCountry,currency){
        switch(fromCountry){
            case "INR": if(toCountry=="AUD"){
                return currency*0.018;
            }
            if(toCountry=="EURO"){
                return currency*0.011;
            }
            if(toCountry=="USD"){
                return currency*0.012;
            }
            break;
            case "AUD":if(toCountry=="INR"){
                return currency*56;
            }
            if(toCountry=="EURO"){
                return currency*0.64;
            }
            if(toCountry=="USD"){
                return currency*0.68;
            }
            break;
        }
    }
