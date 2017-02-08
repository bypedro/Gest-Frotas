<?php
	ob_start();
	session_start();
	if( isset($_SESSION['user'])!="" ){
	}
	
	
	
	include_once 'dbconnect.php';
	
	if ( isset($_POST['btn-signup']) ) {
		
		// clean user inputs to prevent sql injections                     
		
		$gender = trim($_POST['Gender']);
		$gender= strip_tags($gender);
		$gender = htmlspecialchars($gender);
	
		
		if( !$error ) {
			
			$query = ("UPDATE users SET userGenero='$gender' WHERE userId=".$_SESSION['user']);
			$res = mysql_query($query);
				
			if ($res) {
				$errTyp = "success";
				$errMSG = "sf";
				unset($genero);
			} else {
				$errTyp = "danger";
				$errMSG = "Something went wrong, try again later...";	
			}	
				
		}
		
		
	}
?>

<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Coding Cage - Login & Registration System</title>
<link rel="stylesheet" href="assets/css/bootstrap.min.css" type="text/css"  />
<link rel="stylesheet" href="style.css" type="text/css" />

       

</head>
<body>

<div class="container">




</body>
</html>
<?php ob_end_flush(); ?>