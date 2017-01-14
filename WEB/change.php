<?php
	ob_start();
	session_start();
	if( isset($_SESSION['user'])!="" ){
	}
	include_once 'dbconnect.php';
	
	if ( isset($_POST['btn-signup']) ) {
		
		// clean user inputs to prevent sql injections
		$pass = trim($_POST['pass']);
		$pass = strip_tags($pass);
		$pass = htmlspecialchars($pass);
		
		if (empty($pass)){
			$error = true;
			$passError = "Please enter password.";
		} else if(strlen($pass) < 6) {
			$error = true;
			$passError = "Password must have atleast 6 characters.";
		}
		
		// password encrypt using SHA256();
		$password = hash('sha256', $pass);
		
		if( !$error ) {
			
			$query = ("UPDATE users SET userPass='$password' WHERE userId=".$_SESSION['user']);
			$res = mysql_query($query);
				
			if ($res) {
				$errTyp = "success";
				$errMSG = "sf";
				unset($name);
				unset($email);
				unset($adress);
				unset($pass);
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

	<div id="login-form">
    <form method="post" action="<?php echo htmlspecialchars($_SERVER['PHP_SELF']); ?>" autocomplete="off">
    
    	<div class="col-md-12">
        
           
            
            <div class="form-group">
            	<div class="input-group">
                <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
            	<input type="password" name="pass" class="form-control" placeholder="Nova Password" maxlength="15" />
                </div>
                <span class="text-danger"><?php echo $passError; ?></span>
            </div>

            <div class="form-group">
            	<button type="submit" class="btna" name="btn-signup">Actualizar</button>
				<button class="btna" type=button onClick="parent.location='Perfil.php'">Voltar</button>
            </div>
        
        </div>
   
    </form>
    </div>	

</div>

</body>
</html>
<?php ob_end_flush(); ?>