var app = require('http').createServer(handler);
var io = require('socket.io')(app);
var _ = require('underscore');
var unitySocketID = -1;

console.log("hello :)");

app.listen(9090);

function handler(req, res) {

}

io.on('connection', function (socket) {
    var ip = socket.request.connection._peername.address;
    console.log("new client" + ip);

    socket.on('tfjs-class1', function (data) {
      console.log('class1:'+data);
      if(unitySocketID !=-1){
        var unitySocket = _.findWhere(io.sockets.sockets, {id: unitySocketID});
        //unitySocket.emit("unity-center",data);
      }
    });

    socket.on('tfjs-class2', function (data) {
      console.log('class2:'+data);
      if(unitySocketID !=-1){
        var unitySocket = _.findWhere(io.sockets.sockets, {id: unitySocketID});
        //unitySocket.emit("unity-left",data);
      }
    });

    socket.on('unity-start', function (data) {
      console.log(data);
      unitySocketID = socket.id;
      console.log("unity connected.");
  });


    socket.on('disconnect', function (data) {
        console.log('client disconnected');
        if(socket.id == unitySocketID){
          unitySocketID = -1;
        }
    });
});
