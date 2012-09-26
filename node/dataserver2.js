var http = require('http');
var sql = require('node-sqlserver');
var fs = require('fs');
var util = require('util');

var fileCache;
fs.readFile("C:\\Users\\ANTON\\Documents\\GitHub\\nodejsdublin-28-06-2012\\data\\output2.json", function(err, file) {
                fileCache = file;
        });
var sendFile = function(conn, file) {
       conn.writeHead(200, {"Content-Type": "application/json", "Content-Length": file.length});
       conn.end(file);
}
http.createServer(function (req, res) {
  
  sendFile(res, fileCache);
		
	/*	
		var conn_str = "Driver={SQL Server Native Client 11.0};Server=(local);Database=nodejstest;Trusted_Connection={Yes}";
		var databasecdc = "SELECT TOP 10000 * FROM dbo.testtable2"; 
			_res.writeHead(200, { 'Content-Type': 'application/json' })
			var stmt = sql.query(conn_str, databasecdc);
			var item = {};
			
			stmt.on('column', function (idx, data, more) { 
					switch(idx){
						case 0 :
							item.name = data;
							break;
						case 1 :
							item.table = data;
							break;
						case 2 :
							item.date = data;
							break;
						case 3 : 
							_res.write(JSON.stringify(item));
						}
					
			});
			stmt.on('error', function (err) { console.log("We had an error :-( " + err); });

			stmt.on('done', function () { _res.end(); });
			*/
	}).listen(8002, '127.0.0.1');
console.log('Server running at http://127.0.0.1:8002/');