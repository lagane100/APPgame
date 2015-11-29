<?php
	require 'connect.php';
	$IMEI = $_POST["IMEI"];
	$results = mysql_query("SELECT UID,nickname FROM login WHERE IMEI = '$IMEI'");
	$row = mysql_fetch_array($results);
	if(count($row) != 0){
		echo json_encode($row);
	}
	else{
		echo "need new account";
	}

	mysql_close($connection);
?>
