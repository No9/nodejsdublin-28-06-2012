var http = require('http');
var request  = require('request');

http.createServer(function (req, resp) {

request('http://www.google.com', handler);
request('http://www.google.com', handler);

var count = 0;
function handler(error, response, body) {
		if (!error && resp.statusCode == 200) {
		    count++;
		    resp.write(body) // Print the google web page.
		  	if (count == 2) {
			      resp.end();
			}
	}
}


}).listen(1337, '127.0.0.1');
