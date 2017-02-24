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
<link rel="stylesheet" href="circle.css" type="text/css" />

 <style type="text/css">

            .clearfix:before,.clearfix:after {content: " "; display: table;}
            .clearfix:after {clear: both;}
            .clearfix {*zoom: 1;}

        </style>


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
			 			  <span class=""></span><img src="logos/perfil.png">&nbsp;&nbsp;<span class=""></span></a>
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
    
			
	<div class="clearfix">
                <div class="c100 p25 green">
                    <span>50%</span>
                    <div class="slice">
                        <div class="bar"></div>
                        <div class="fill"></div>
                    </div>
              
				</div>
				
				<div class="c100 p25 orange">
                    <span>500€</span>
                    <div class="slice">
                        <div class="bar"></div>
                        <div class="fill"></div>
                    </div>
              
				</div>
				
				<div class="c100 p25 green">
                    <span>50%</span>
                    <div class="slice">
                        <div class="bar"></div>
                        <div class="fill"></div>
                    </div>
              
				</div>
				
              
		

		
		</div>
		
		 <div class="page-header">
		</div>
		
    	<div class="page-header">
<<<<<<< HEAD
		
		
			</div>
				

		<ul class="tab">
  <li><a href="javascript:void(0)" class="tablinks" onclick="openCity(event, 'Geral')" id="defaultOpen">Dados Gerais</a></li>
  <li><a href="javascript:void(0)" class="tablinks" onclick="openCity(event, 'Pessoal')">Dados Pessoais</a></li>
  <li><a href="javascript:void(0)" class="tablinks" onclick="openCity(event, 'notas')">Notas</a></li>
  <li><a href="javascript:void(0)" class="tablinks" onclick="openCity(event, 'historico')">Histórico</a></li>
	</ul>
    	
		

	<div id="Geral" class="tabcontent">
  <p><table cellspacing='0'>
			<tr><th>ID</th><td><?php echo $userRow['CodUser']; ?></td></tr>
			<tr><th>Imagem</th><td><img class="imga" src="logos/perfil.png"></td></tr>
			<tr><th>Utilizador</th><td><?php echo $userRow['Nome_Registo']; ?></td></tr>
			<tr><th>Email</th><td><?php echo $userRow['Email']; ?></td></tr>
			<tr><th>País</th><td><?php echo $userRow['']; ?></td></tr>
			<tr><th>Género</th><td><?php echo $userRow['Genero']; ?></td></tr>
			<tr><th>Data Contratação</th><td><?php echo $userRow['Data_Contratacao']; ?></td></tr>
			</table>
			</p>
	<br>
	<p align="right">
		<button class="btnnn" type=button onClick="parent.location='#.php'">?</button>
		<button class="btnn" type=button onClick="parent.location='editarperfil.php'">&#10000; Alterar</button>
	</p>
	</div>
	
	<div id="Pessoal" class="tabcontent">
  <p><table cellspacing='0'>
			<tr><th>Nome Próprio</th><td><?php echo $userRow['Nome_Proprio']; ?></td></tr>
			<tr><th>Apelido</th><td><?php echo $userRow['Apelido']; ?></td></tr>
			<tr><th>Data Nascimento</th><td><?php echo $userRow['Data_Nascimento']; ?></td></tr>
			<tr><th>Habilitações</th><td><?php echo $userRow['Habilitacoes']; ?></td></tr>
			<tr><th>Pagamentos</th><td><?php echo $userRow['Pagamentos_Hora']; ?></td></tr>
			<tr><th>Morada</th><td><?php echo $userRow['Rua']; ?></td></tr>
			<tr><th>Telemóvel</th><td><?php echo $userRow['N_Telemovel']; ?></td></tr>
			<tr><th>Telefone</th><td><?php echo $userRow['N_Telefone']; ?></td></tr>
			</table>
			</p>
	<br>
	<p align="right">
		<button class="btnnn" type=button onClick="parent.location='#.php'">?</button>
		<button class="btnn" type=button onClick="parent.location='editarperfil.php' ">&#10000; Alterar</button>
	</p>
	</div>
	
	<div id="historico" class="tabcontent">
	<p><table cellspacing='0'>
			<tr><th>Work History</th><td>dfgdfgdfgdfg</td></tr>
			<tr><th>Tempo Trabalho</th><td>456456564456</td></tr>
			</table>
			</p>
	</div>
	
	<div id="notas" class="tabcontent">
	<p><table cellspacing='0'>
			<tr><th>Notas Contacto</th><td><?php echo $userRow['Notas_contacto']; ?></td></tr>
			<tr><th>Notas Contracto</th><td><?php echo $userRow['Notas_Contracto']; ?></td></tr>
=======
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
>>>>>>> origin/master
			</table>
			</p>
	<br>
	<p align="right">
		<button class="btnnn" type=button onClick="parent.location='#.php'">?</button>
<<<<<<< HEAD
		<button class="btnn" type=button onClick="parent.location='editarperfil.php'">&#10000; Alterar</button>
	</p>
	</div>
	

	
	</div>
	<script>
	
=======
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
>>>>>>> origin/master
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