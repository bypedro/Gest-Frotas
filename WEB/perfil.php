<?php
	ob_start();
	session_start();
	require_once 'dbconnect.php';
	
	// if session is not set this will redirect to login page
	if( !isset($_SESSION['user']) ) {
		header("Location: index.php");
		exit;
	}
	// select loggedin users detail
	$res=mysql_query("SELECT * FROM users WHERE userId=".$_SESSION['user']);
	$userRow=mysql_fetch_array($res);
?>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Perfil - <?php echo $userRow['userName']; ?></title>
<link rel="stylesheet" href="assets/css/bootstrap.min.css" type="text/css"  />
<link rel="stylesheet" href="style.css" type="text/css" />
</head>
<body>

	<nav class="navbar navbar-default navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
            <span class="sr-only">Toggle navigation</span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
          <a class="navbar-brand" href="home.php">Início</a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
          <ul class="nav navbar-nav">
            <li class="active"><a href="#">Suporte</a></li>
            <li><a href="#">texto</a></li>
            <li><a href="manageuser.php">Texto</a></li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
            
            <li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
			  <span class="glyphicon glyphicon-user"></span>&nbsp;Olá,  <?php echo $userRow['userName']; ?>&nbsp;<span class="caret"></span></a>
              <ul class="dropdown-menu">
				<li><a href="#"><span class=""></span>&#9742; Serviços</a></li>
                <li><a href="#"><span class="glyphicon glyphicon-user"></span>&nbsp;Perfil</a></li>
				<li><a href="logout.php?logout"><span class="glyphicon glyphicon-log-out"></span>&nbsp;Sair</a></li>
              </ul>
            </li>
          </ul>
        </div><!--/.nav-collapse -->
      </div>
    </nav> 

		
		
	
	<div id="wrapper">

	<div class="container">
    
    	<div class="page-header">
    	<h3>Perfil</h3>
    	</div>
		
		
	
	<table cellspacing='0'>
	<tr><th>ID</th><td><?php echo $userRow['userId']; ?></td></tr>	
	<tr><th>Utilizador </th><td><?php echo $userRow['userName']; ?></td></tr>
	<tr><th>Data Registo </th><td><?php echo $userRow['userRegisto']; ?></td></tr>
	<tr><th>Email </th><td><?php echo $userRow['userEmail']; ?></td></tr>
	<tr><th>Endereço </th><td><?php echo $userRow['userRua']; ?></td></tr>
   

</table>
		<br>
		<p align="right">
		<button class="btnn" type=button onClick="parent.location='changepw.php'">Alterar Password</button>
		</p>

        <div class="row">
        <div class="col-lg-12">

        </div>
        </div>
    
    </div>
    
	<div class="footer"><a class="btne" href="#"><span><img src="logos/fb.png"</img></span></a>
	<a class="btne" href="#"><span><img src="logos/tt.png"</img></span></a>
	<a class="btne" href="#"></i><span><img src="logos/gg.jpg"</img></span></a>
	<a class="btne" href="#"></i><span><img src="logos/em.png"</img></span></a>
	&#124
	 FRONTALINES © 2017 
	
	</div>
	
	
    </div>
	
	
 

	
    <script src="assets/jquery-1.11.3-jquery.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    
</body>
</html>
<?php ob_end_flush(); ?>