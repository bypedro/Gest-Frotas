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
	$res=mysql_query("SELECT * FROM utilizador WHERE CodUser=".$_SESSION['user']);
	$userRow=mysql_fetch_array($res);
?>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Perfil - <?php echo $userRow['Nome_Registo']; ?></title>
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
            <li class=""><a href="#">Suporte</a></li>
            <li><a href="#">texto</a></li>
            <li><a href="manageuser.php">Texto</a></li>
          </ul>
          <ul class="nav navbar-nav navbar-right">
            
            <li class="dropdown">
              <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">
			  <span class="glyphicon glyphicon-user"></span>&nbsp;Olá,  <?php echo $userRow['Nome_Registo']; ?>&nbsp;<span class="caret"></span></a>
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
    	</div>
		
	<ul class="tab">
  <li><a href="javascript:void(0)" class="tablinks" onclick="openCity(event, 'Geral')" id="defaultOpen">Dados Gerais</a></li>
  <li><a href="javascript:void(0)" class="tablinks" onclick="openCity(event, 'Pessoal')">Dados Pessoais</a></li>
  <li><a href="javascript:void(0)" class="tablinks" onclick="openCity(event, 'historico')">Histórico</a></li>
	</ul>

	
	<div id="Geral" class="tabcontent">
  <p><table cellspacing='0'>
			<tr><th>ID</th><td><?php echo $userRow['CodUser']; ?></td></tr>
			<tr><th>Utilizador</th><td><?php echo $userRow['Nome_Registo']; ?></td></tr>
			<tr><th>Email</th><td><?php echo $userRow['Email']; ?></td></tr>
			<tr><th>Endereço</th><td><?php echo $userRow['Rua']; ?></td></tr>
			<tr><th>Género</th><td><?php echo $userRow['Genero']; ?></td></tr>
			</table>
			</p>
	<br>
	<p align="right">
		<button class="btnnn" type=button onClick="parent.location='#.php'">?</button>
		<button class="btnn" type=button onClick="parent.location='changepw.php'">Alterar</button>
	</p>
	</div>
	<div id="Pessoal" class="tabcontent">
  <p>XXXXXXXXXXXXXXXX</p>
	</div>
	<div id="historico" class="tabcontent">
	<p>YYYYYYYYYYYYYY</p>
	</div>
	</div>
	<script>
	function openCity(evt, cityName) {
		var i, tabcontent, tablinks;
		tabcontent = document.getElementsByClassName("tabcontent");
		for (i = 0; i < tabcontent.length; i++) {
			tabcontent[i].style.display = "none";
		}
		tablinks = document.getElementsByClassName("tablinks");
		for (i = 0; i < tablinks.length; i++) {
			tablinks[i].className = tablinks[i].className.replace(" active", "");
		}
		document.getElementById(cityName).style.display = "block";
		evt.currentTarget.className += " active";
	}

	// Get the element with id="defaultOpen" and click on it
	document.getElementById("defaultOpen").click();
	</script>
		
    
    </div>
    

	
	
    </div>
	
	
 

	
    <script src="assets/jquery-1.11.3-jquery.min.js"></script>
    <script src="assets/js/bootstrap.min.js"></script>
    
</body>
</html>
<?php ob_end_flush(); ?>