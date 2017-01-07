$api = "http://localhost:5000/api/Tick"

# Testing new tick item
function new ($x) { irm $api -Method Post -Body ($x | convertto-json) -ContentType 'application/json' }

function get ($x="") { $url = $api ;  if ($x -ne [String]::Empty) { $url = "$api/$x" } ; irm -uri $url  -ContentType 'application/json' }

function delete ($x) { irm $api/$x -Method delete  }  