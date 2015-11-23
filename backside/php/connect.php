<?php
	$connection = mysql_connect("localhost","root","Tryit830528");
	if (!$connection){
		die('Could not connect: ' . mysql_error());
	}
	mysql_query("SET NAMES 'utf8'");
	mysql_select_db("mainServer");
?>
