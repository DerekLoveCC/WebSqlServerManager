var http = require('http');
var url = require('url');
http.createServer(function(req,res){
  console.log(req);
  var creq = http.get('http://www.youtube.com', function(creq){
    creq.pipe(res);
  });
  req.pipe(creq);
}).listen(7676);

// var net = require('net');
// var message = require('fs').createReadStream('./message.txt');
// var server = net.createServer();
// server.on('connection', function (socket) {
//   socket.setTimeout(10 * 1000);
//   socket.pause();
//   socket.on('timeout',function(){
//     socket.resume();
//     socket.pipe(message);
//   });
// });

// server.listen(6556, 'localhost');




// var Readable = require('stream').Readable;
// var readableStream = new Readable();
// var c = 97;
// readableStream._read = function () {
//   readableStream.push(String.fromCharCode(c++));
//   if (c > 'z'.charCodeAt(0)) {
//     readableStream.push('\n');
//     readableStream.push(null);
//   }
// };
// readableStream.pipe(process.stdout);


// var fs = require('fs');
// var path = require('path');
// console.log(path.sep);
// console.log(path.delimiter);

// var read = fs.createReadStream('./gulpfile.js');
// var writer  = fs.createWriteStream('./gulpfile_copy.js');
// read.on('data',function(data){
//   writer.write(data);
// });

// read.on('end',function(){
//   console.log('read finished');
//   writer.end();
// });