var http = require('http');

http.createServer(function (req, resp) {

var options1 = {
  host: 'localhost',
  port: 8001,
  path: '/',
  method: 'GET'
};

var options2 = {
  host: 'localhost',
  port: 8002,
  path: '/',
  method: 'GET'
};

var counter = 0;
var data1 = "";
var req = http.request(options1, function(res) {
  res.setEncoding('utf8');
  res.on('data', function (chunk) {
    data1 += chunk;
	//resp.write(chunk);
  });
  
  res.on('end', function(){
	counter++;
	if(counter == 2)
	{
		resp.end(data1 + data2);
	}
  });
  
});

req.end();

var data2 = "";
var req2 = http.request(options2, function(res) {
  res.setEncoding('utf8');
  
  res.on('data', function (chunk) {
	data2 += chunk;
	//resp.write(chunk);
  });
  
  res.on('end', function(){
	counter++;
	if(counter == 2)
	{
		resp.end(data1 + data2);
	}
  });
  
});

req2.end();


}).listen(1337, '127.0.0.1');
