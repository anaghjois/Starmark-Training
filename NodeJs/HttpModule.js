const http=require("http")
http.createServer(function(req,res){
    console.log(req.url);
    if(req.url=="/employee"){
        res.write("EMployee Page")
    }
    else if(req.url=="/student")
    {
        res.write("Welcome to student page")
    }
    else{
        res.write("Default Page")
    }
    res.end()
}).listen(1509);