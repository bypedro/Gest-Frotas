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
		
		$email = trim($_POST['email']);
		$email = strip_tags($email);
		$email = htmlspecialchars($email);
		
		$adress = trim($_POST['adress']);
		$adress= strip_tags($adress);
		$adress = htmlspecialchars($adress);
		
		if (empty($pass)){
			$error = true;
			$passError = "Please enter password.";
		} else if(strlen($pass) < 6) {
			$error = true;
			$passError = "Password must have atleast 6 characters.";
		}
		
		//basic email validation
		if ( !filter_var($email,FILTER_VALIDATE_EMAIL) ) {
			$error = true;
			$emailError = "Please enter valid email address.";
		} else {
			// check email exist or not
			$query = "SELECT userEmail FROM users WHERE userEmail='$email'";
			$result = mysql_query($query);
			$count = mysql_num_rows($result);
			if($count!=0){
				$error = true;
				$emailError = "Provided Email is already in use.";
			}
		}
		
		// password encrypt using SHA256();
		$password = hash('sha256', $pass);
		
		if( !$error ) {
			
			$query = ("UPDATE users SET userPass='$password', userEmail='$email', userRua='$adress' WHERE userId=".$_SESSION['user']);
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
                <span class=""><span class=""></span></span>
            	<input type="email" name="email" class="" placeholder="Email" maxlength="40" value="<?php echo $email ?>" />
                </div>
                <span class="text-danger"><?php echo $emailError; ?></span>
            </div>
			<br>
            <div class="form-group">
            	<div class="input-group">
                <span class=""><span class=""></span></span>
            	<input type="password" name="pass" class="" placeholder="Password" maxlength="15" />
                </div>
                <span class="text-danger"><?php echo $passError; ?></span>
            </div>
			<br>
			<div class="form-group">
            	<div class="input-group">
                <span class=""><span class=""></span></span>
            	<input type="adress" name="adress" class="" placeholder="Morada" maxlength="100" value="<?php echo $adress ?>" />
                </div>
                <span class="text-danger"><?php echo $emailError; ?></span>
            </div>
			<br>
			<center><div class="form-group">
            	<button type="submit" class="btnn" name="btn-signup">Actualizar</button>
				<button class="btnnn" type=button onClick="parent.location='Perfil.php'">Voltar</button>
            </div></center>
        
        </div>
   
    </form>
    </div>	

</div>

</body>
</html>
<?php ob_end_flush(); ?>