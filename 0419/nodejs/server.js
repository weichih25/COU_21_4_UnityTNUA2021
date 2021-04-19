var app = require('http').createServer(handler);
var io = require('socket.io')(app);

app.listen(9090);

function handler(req, res) {

}

io.on('connection', function (socket) {
    var ip = socket.request.connection._peername.address;
    console.log("new client" + ip);

    //console.log(ip);
    socket.on('sayHi', function (data) {
      console.log(data);
    });


    socket.on('disconnect', function (data) {
        console.log('client disconnected');
    });
});
