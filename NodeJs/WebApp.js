const http = require("http");
const fs = require("fs");
const dir=__dirname
const querystring = require('querystring')
const httpParse=require('url').parse

function displayPage(res,url){
    const file=dir+url+".html"
    fs.createReadStream(file).pipe(res);
}
function ErrorPage(res){
    res.writeHead(200,{'Content-type':'text/html'})
    res.write("<h1 style='color:red'>OOPs ! Something is wrong</h1>")
    res.write("<hr>")
    res.write("<h2>Page is Not Found<h2>")
}
http.createServer((req,res)=>{
    if(req.method=="GET"){
        const query=httpParse(req.url).query
        if(query!=null){
            let obj=httpParse(req.url,true).query
            const msg=`Thanks Mr.${obj.txtName} for registering with us ! UR email is ${obj.txtEmail} is registered and will be contacted`;
            res.write(msg)
            res.end()
            return;
        }
    }
    else if(req.method=='POST'){
        let postedData=""
        req.on("data",function(inputs){
            postedData+=inputs
        })
            req.on("end",function(){
                let post=querystring.parse(postedData)
                const msg = `Thanks Mr.${post['txtName']} for registering with Us! UR EMail ${post['txtEmail']} is registered and will be contacted`;
                res.write(msg)
                res.end()
                return;
            })
    }
    
    switch(req.url){
        case "/favicon.ico":
            res.end();
            break;
        case "/RegisterPage":
            displayPage(res,req.url)
            break;
        case "/HomePage":
            displayPage(res,req.url)
            break;
        default:
            ErrorPage(res)
            // res.end()
            break;    
    }
   
}).listen(1509)