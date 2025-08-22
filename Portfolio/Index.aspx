<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Portfolio.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Himel</title>
    <!--icon-->
    <link rel="shortcut icon" href="./images/logo.ico" type="image/x-icon">
    <link rel="stylesheet" href="css/style.css">

    <!-- Google Fonts -->
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&family=Press+Start+2P&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <main>
                <!--sidebar-->
                <aside class="sidebar" data-sidebar>
                    <div class="sidebar-info">
                        <figure class="avatar-box">
                            <img src="images/hero.png" alt="Himel Hossain" width="80">
                        </figure>

                        <div class="info-content">
                            <h1 class="name" title="Himel Hossain">Himel Hossain</h1>
                            <p class="title">CS Undergrad</p>
                        </div>
                        <button class="info_more-btn" data-sidebar-btn>
                            <span>Show Contacts</span>
                            <ion-icon class="info-btn" name="chevron-down"></ion-icon>
                        </button>
                    </div>
                    <div class="sidebar-info_more">
                        <div class="separator"></div>
                        <ul class="contacts-list">
                            <li class="contact-item">
                                <div class="icon-box">
                                    <ion-icon name="mail-outline"></ion-icon>
                                </div>
                                <div class="contact-info">
                                    <p class="contact-title">Email</p>
                                    <a href="mailto:mdhimelhossain512@gmail.com" class="contact-link">himel@gmail.com</a>
                                </div>
                            </li>
                            <li class="contact-item">
                                <div class="icon-box">
                                    <ion-icon name="phone-portrait-outline"></ion-icon>
                                </div>
                                <div class="contact-info">
                                    <p class="contact-title">Phone</p>
                                    <a href="tel:+8801608639395" class="contact-link">+88016*****395</a>
                                </div>
                            </li>
                            <li class="contact-item">
                                <div class="icon-box">
                                    <ion-icon name="calendar-outline"></ion-icon>
                                </div>
                                <div class="contact-info">
                                    <p class="contact-title">Birthday</p>
                                    <time datetime="2003-09-21">September 21, 2003</time>
                                </div>
                            </li>
                            <li class="contact-item">
                                <div class="icon-box">
                                    <ion-icon name="location-outline"></ion-icon>
                                </div>
                                <div class="contact-info">
                                    <p class="contact-title">Location</p>
                                    <address>Dhamrai, Dhaka, Bangladesh</address>
                                </div>
                            </li>
                        </ul>
                        <div class="separator"></div>
                        <ul class="social-list">
                            <li class="social-item">
                                <a href="https://www.facebook.com/himel.hossain.md" class="social-link">
                                    <ion-icon name="logo-facebook"></ion-icon>
                                </a>
                            </li>
                            <li class="social-item">
                                <a href="#" class="social-link">
                                    <ion-icon name="logo-twitter"></ion-icon>
                                </a>
                            </li>
                            <li class="social-item">
                                <a href="https://www.instagram.com/nocturne_soul.x/" class="social-link">
                                    <ion-icon name="logo-instagram"></ion-icon>
                                </a>
                            </li>
                        </ul>
                    </div>
                </aside>
                <!--Main content-->
                <div class="main-content">
                    <!--Navbar-->
                    <nav class="navbar">
                        <ul class="navbar-list">
                            <li class="navbar-item">
                                <button class="navbar-link active" data-nav-link>About</button>
                            </li>
                            <li class="navbar-item">
                                <button class="navbar-link" data-nav-link>Resume</button>
                            </li>
                            <li class="navbar-item">
                                <button class="navbar-link" data-nav-link>Portfolio</button>
                            </li>
                            <li class="navbar-item">
                                <button class="navbar-link" data-nav-link>Blog</button>
                            </li>
                            <li class="navbar-item">
                                <button class="navbar-link" data-nav-link>NPM</button>
                            </li>
                            <li class="navbar-item">
                                <button class="navbar-link" data-nav-link>Contact</button>
                            </li>
                        </ul>
                    </nav>
                    <!--About-->
                    <article class="about active" data-page="about">
                        <header>
                            <h2 class="h2 article-title">About me</h2>
                        </header>
                        <section class="about-text">
                            <p>
                                Hi, I'm a 3rd-year Computer Science and Engineering undergraduate at Khulna University of Engineering and Technology(<a href="https://www.kuet.ac.bd" target="_blank" style="text-decoration: underline; color: #00BFFF; pointer-events: cursor; display: inline;"><i>KUET</i></a>), originally from Dhaka, Bangladesh.
                            </p>
                            <p>
                                I'm passionate about building practical and user-friendly software solutions. I’ve developed several Android applications and websites, combining my technical skills with a focus on real-world impact.My interests lie in mobile and web development, and I enjoy solving complex problems through clean, efficient code. I'm always eager to learn new technologies, collaborate with others, and take on challenges that help me grow as a developer.

                    I’m currently seeking opportunities to work on innovative projects and expand my experience in the tech industry.
                            </p>
                        </section>
                        <!--Service-->
                        <section class="service">
                            <h3 class="h3 service-title">What I'm doing</h3>
                            <ul class="service-list">
                                <li class="service-item">
                                    <div class="service-icon-box">
                                        <img src="images/icon-design.svg" alt="design icon" width="40">
                                    </div>
                                    <div class="service-content-box">
                                        <h4 class="h4 service-item-title">Web design</h4>
                                        <p class="service-item-text">
                                            The most modern and high-quality design made at a professional level.
                                        </p>
                                    </div>
                                </li>
                                <li class="service-item">
                                    <div class="service-icon-box">
                                        <img src="images/icon-dev.svg" alt="web development icon" width="40">
                                    </div>
                                    <div class="service-content-box">
                                        <h4 class="h4 service-item-title">Web development</h4>
                                        <p class="service-item-text">
                                            high-quality development of sites at the professional level.
                                        </p>
                                    </div>
                                </li>
                                <li class="service-item">
                                    <div class="service-icon-box">
                                        <img src="images/icon-app.svg" alt="mobile app icon" width="40">
                                    </div>
                                    <div class="service-content-box">
                                        <h4 class="h4 service-item-title">Mobile app</h4>
                                        <p class="service-item-text">
                                            Professional development of applications for iOS and Android.
                                        </p>
                                    </div>
                                </li>
                                <li class="service-item">
                                    <div class="service-icon-box">
                                        <img src="images/icon-photo.svg" alt="camera icon" width="40">
                                    </div>
                                    <div class="service-content-box">
                                        <h4 class="h4 service-item-title">Photography</h4>
                                        <p class="service-item-text">
                                            I make high-quality photos of any category at a professional level.
                                        </p>
                                    </div>
                                </li>
                            </ul>
                        </section>
                        <!-- testimonials-->
                        <section class="testimonials">
                            <h3 class="h3 testimonials-title">Testimonials</h3>
                            <ul class="testimonials-list has-scrollbar">
                                <li class="testimonials-item">
                                    <div class="content-card" data-testimonials-item>
                                        <figure class="testimonials-avatar-box">
                                            <img src="images/avatar-1.png" alt="Niloy Hossain" width="60" data-testimonials-avatar>
                                        </figure>
                                        <h4 class="h4 testimonials-item-title" data-testimonials-title>Niloy Hossain</h4>
                                        <div class="testimonials-text" data-testimonials-text>
                                            <p>
                                                Himel Hossain is a talented and dedicated individual with a passion for technology and design. His skills in web development and UI/UX design are impressive, and he consistently delivers high-quality work. Himel's creativity and attention to detail make him a valuable asset to any project.
                                            </p>
                                        </div>
                                    </div>
                                </li>
                                <li class="testimonials-item">
                                    <div class="content-card" data-testimonials-item>
                                        <figure class="testimonials-avatar-box">
                                            <img src="images/avatar-2.png" alt="Gigi Hadid" width="60" data-testimonials-avatar>
                                        </figure>
                                        <h4 class="h4 testimonials-item-title" data-testimonials-title>Gigi Hadid</h4>
                                        <div class="testimonials-text" data-testimonials-text>
                                            <p>
                                                Himel Hossain is a passionate technologist with a keen eye for design. He excels in web development and UI/UX,
                                    consistently producing work that is both innovative and polished. His ability to combine creativity with meticulous
                                    attention to detail makes him an invaluable contributor to any project.
                                            </p>
                                        </div>
                                    </div>
                                </li>
                                <li class="testimonials-item">
                                    <div class="content-card" data-testimonials-item>
                                        <figure class="testimonials-avatar-box">
                                            <img src="images/avatar-3.png" alt="Elice Huntsman" width="60" data-testimonials-avatar>
                                        </figure>
                                        <h4 class="h4 testimonials-item-title" data-testimonials-title>Elice Huntsman</h4>
                                        <div class="testimonials-text" data-testimonials-text>
                                            <p>
                                                With strong skills in technology and design, Himel Hossain consistently delivers outstanding results in web development
                                    and user interface design. His dedication and creative approach ensure that every project he works on benefits from high
                                    standards and thoughtful execution.
                                            </p>
                                        </div>
                                    </div>
                                </li>

                            </ul>
                        </section>

                        <!--Testimonails modal-->
                        <div class="modal-container" data-modal-container>
                            <div class="overlay" data-overlay></div>
                            <section class="testimonials-modal">
                                <button class="modal-close-btn" data-modal-close-btn>
                                    <ion-icon name="close-outline"></ion-icon>
                                </button>
                                <div class="modal-img-wrapper">
                                    <figure class="modal-avatar-box">
                                        <img src="images/avatar-1.png" alt="Niloy Hossain" width="80" data-modal-img>
                                    </figure>
                                    <img src="images/icon-quote.svg" alt="quote icon">
                                </div>
                                <div class="modal-content">
                                    h4.
                                    <h3 class="modal-title" data-modal-title>Niloy Hossain</h3>
                                    <time datetime="2025-05-30">30 May, 2025</time>
                                    <div data-modal-text>
                                        <p>
                                            Niloy Hossain was hired to create a corporate identity. We were very pleased with the work done. She has a
                                lot of experience and is very concerned about the needs of client. Lorem ipsum dolor sit amet, ullamcous cididt
                                consectetur adipiscing
                                elit, seds do et eiusmod tempor incididunt ut laborels dolore magnarels alia.
                                        </p>
                                    </div>
                                </div>
                            </section>
                        </div>
                        <!--Clients-->
                        <section class="clients">
                            <h3 class="h3 clients-title">Clients</h3>
                            <ul class="clients-list has-scrollbar">
                                <li class="clients-item">
                                    <a href="#">
                                        <img src="images/logo-1-color.png" alt="client logo">
                                    </a>
                                </li>
                                <li class="clients-item">
                                    <a href="#">
                                        <img src="images/logo-2-color.png" alt="client logo">
                                    </a>
                                </li>

                                <li class="clients-item">
                                    <a href="#">
                                        <img src="images/logo-3-color.png" alt="client logo">
                                    </a>
                                </li>

                                <li class="clients-item">
                                    <a href="#">
                                        <img src="images/logo-4-color.png" alt="client logo">
                                    </a>
                                </li>

                                <li class="clients-item">
                                    <a href="#">
                                        <img src="images/logo-5-color.png" alt="client logo">
                                    </a>
                                </li>

                                <li class="clients-item">
                                    <a href="#">
                                        <img src="images/logo-6-color.png" alt="client logo">
                                    </a>
                                </li>
                            </ul>
                        </section>

                    </article>
                    <!--Resume-->
                    <article class="resume" data-page="resume">
                        <header>
                            <h2 class="h2 article-title">Resume</h2>
                        </header>
                        <section class="timeline">
                            <div class="title-wrapper">
                                <div class="icon-box">
                                    <ion-icon name="book-outline"></ion-icon>
                                </div>
                                <h3 class="h3">Education</h3>
                            </div>
                            <ol class="timeline-list">
                                <li class="timeline-item">
                                    <h4 class="h4 timeline-item-title">CSE at Khulna University of Engineering & Technology</h4>
                                    <span>2023 - 2026</span>
                                    <p class="timeline-text">
                                        I am pursuing my BSc degree in Computer Science and Engineering at KUET.
                                    </p>
                                </li>
                                <li class="timeline-item">
                                    <h4 class="h4 timeline-item-title">Science at BPATC School and College</h4>
                                    <span>2019 - 2021</span>
                                    <p class="timeline-text">
                                        I have completed my Higher Secondary Education (HSC) from Science group at BPATC School and College.
                                    </p>
                                </li>
                                <li class="timeline-item">
                                    <h4 class="h4 timeline-item-title">Alhaz Jamal Uddin Ideal High School</h4>
                                    <span>2014 - 2019</span>
                                    <p class="timeline-text">
                                        I have completed my Secondary Education.
                                    </p>
                                </li>
                                <li class="timeline-item">
                                    <h4 class="h4 timeline-item-title">Shailbari Govt. Primary School</h4>
                                    <span>2009 - 2013</span>
                                    <p class="timeline-text">
                                        I have completed my Primary School Education here.
                                    </p>
                                </li>
                            </ol>
                        </section>
                        <section class="timeline">
                            <div class="title-wrapper">
                                <div class="icon-box">
                                    <ion-icon name="book-outline"></ion-icon>
                                </div>
                                <h3 class="h3">Experience</h3>
                            </div>
                            <ol class="timeline-list">
                                <li class="timeline-item">
                                    <h4 class="h4 timeline-item-title">Web Developer</h4>
                                    <span>2023 - Present</span>
                                    <p class="timeline-text">
                                        I have developed many websites and games.
                                    </p>
                                </li>
                                <li class="timeline-item">
                                    <h4 class="h4 timeline-item-title">Mobile App Developer</h4>
                                    <span>2023 - Present</span>
                                    <p class="timeline-text">
                                        I have developed many mobile applications.
                                    </p>
                                </li>

                            </ol>
                        </section>
                        <section class="skill">
                            <h3 class="h3 skills-title">My skills</h3>
                            <ul class="skills-list content-card">
                                <li class="skills-item">
                                    <div class="title-wrapper">
                                        <h5 class="h5">Web design</h5>
                                        <data value="80">80%</data>
                                    </div>
                                    <div class="skill-progress-bg">
                                        <div class="skill-progress-fill" style="width: 80%;"></div>
                                    </div>
                                </li>
                                <li class="skills-item">
                                    <div class="title-wrapper">
                                        <h5 class="h5">Graphic design</h5>
                                        <data value="70">70%</data>
                                    </div>
                                    <div class="skill-progress-bg">
                                        <div class="skill-progress-fill" style="width: 70%;"></div>
                                    </div>
                                </li>
                                <li class="skills-item">
                                    <div class="title-wrapper">
                                        <h5 class="h5">Software development</h5>
                                        <data value="50">50%</data>
                                    </div>
                                    <div class="skill-progress-bg">
                                        <div class="skill-progress-fill" style="width: 50%;"></div>
                                    </div>
                                </li>
                            </ul>
                        </section>

                        <section class="skill">
                            <h3 class="h3 skills-title">Programming Language</h3>
                            <ul class="skills-list content-card">
                                <li class="skills-item">
                                    <div class="title-wrapper">
                                        <h5 class="h5">C</h5>
                                        <data value="80">80%</data>
                                    </div>
                                    <div class="skill-progress-bg">
                                        <div class="skill-progress-fill" style="width: 80%;"></div>
                                    </div>
                                </li>
                                <li class="skills-item">
                                    <div class="title-wrapper">
                                        <h5 class="h5">C++</h5>
                                        <data value="90">90%</data>
                                    </div>
                                    <div class="skill-progress-bg">
                                        <div class="skill-progress-fill" style="width: 90%;"></div>
                                    </div>
                                </li>
                                <li class="skills-item">
                                    <div class="title-wrapper">
                                        <h5 class="h5">Java</h5>
                                        <data value="70">70%</data>
                                    </div>
                                    <div class="skill-progress-bg">
                                        <div class="skill-progress-fill" style="width: 70%;"></div>
                                    </div>
                                </li>
                                <li class="skills-item">
                                    <div class="title-wrapper">
                                        <h5 class="h5">Python</h5>
                                        <data value="80">80%</data>
                                    </div>
                                    <div class="skill-progress-bg">
                                        <div class="skill-progress-fill" style="width: 80%;"></div>
                                    </div>
                                </li>
                                <li class="skills-item">
                                    <div class="title-wrapper">
                                        <h5 class="h5">JavaScript</h5>
                                        <data value="90">90%</data>
                                    </div>
                                    <div class="skill-progress-bg">
                                        <div class="skill-progress-fill" style="width: 90%;"></div>
                                    </div>
                                </li>
                                <li class="skills-item">
                                    <div class="title-wrapper">
                                        <h5 class="h5">PHP</h5>
                                        <data value="70">70%</data>
                                    </div>
                                    <div class="skill-progress-bg">
                                        <div class="skill-progress-fill" style="width: 70%;"></div>
                                    </div>
                                </li>
                            </ul>
                        </section>

                        <section class="skill">
                            <h3 class="h3 skills-title">Language Proficiency</h3>
                            <ul class="skills-list content-card">
                                <li class="skills-item">
                                    <div class="title-wrapper">
                                        <h5 class="h5">English</h5>
                                        <data value="80">80%</data>
                                    </div>
                                    <div class="skill-progress-bg">
                                        <div class="skill-progress-fill" style="width: 80%;"></div>
                                    </div>
                                </li>
                                <li class="skills-item">
                                    <div class="title-wrapper">
                                        <h5 class="h5">Bangla</h5>
                                        <data value="100">100%</data>
                                    </div>
                                    <div class="skill-progress-bg">
                                        <div class="skill-progress-fill" style="width: 100%;"></div>
                                    </div>
                                </li>
                                <li class="skills-item">
                                    <div class="title-wrapper">
                                        <h5 class="h5">Hindi</h5>
                                        <data value="70">70%</data>
                                    </div>
                                    <div class="skill-progress-bg">
                                        <div class="skill-progress-fill" style="width: 70%;"></div>
                                    </div>
                                </li>
                            </ul>
                        </section>
                        <button class="cv-btn">
                            <a a href="CV/CV_Md_Himel_Hossain.pdf" download="CV_Md_Himel_Hossain.pdf">Download CV</a>
                            <ion-icon name="download-outline"></ion-icon>
                        </button>

                    </article>
                    <!--Portfolio-->
                    <article class="portfolio" data-page="portfolio">
                        <header>
                            <h2 class="h2 article-title">Portfolio</h2>
                        </header>
                        <section class="projects">
                            <ul class="filter-list">
                                <li class="filter-item">
                                    <button class="active" data-filter-btn>All</button>
                                </li>
                                <li class="filter-item">
                                    <button data-filter-btn>Web design</button>
                                </li>
                                <li class="filter-item">
                                    <button data-filter-btn>Applications</button>
                                </li>
                                <li class="filter-item">
                                    <button data-filter-btn>Web development</button>
                                </li>
                            </ul>

                            <div class="filter-select-box">
                                <button class="filter-select" data-select>
                                    <div class="select-value" data-selecct-value>Select category</div>
                                    <div class="select-icon">
                                        <ion-icon name="chevron-down"></ion-icon>
                                    </div>
                                </button>
                                <ul class="select-list">
                                    <li class="select-item">
                                        <button data-select-item>All</button>
                                    </li>
                                    <li class="select-item">
                                        <button data-select-item>Web design</button>
                                    </li>
                                    <li class="select-item">
                                        <button data-select-item>Applications</button>
                                    </li>
                                    <li class="select-item">
                                        <button data-select-item>Web development</button>
                                    </li>
                                </ul>
                            </div>
                            <ul class="project-list">
                                <li class="project-item active" data-filter-item data-category="web development">
                                    <a href="https://github.com/Himel-032/Coffee-shop-website" target="_blank">
                                        <figure class="project-img">
                                            <div class="project-item-icon-box">
                                                <ion-icon name="eye-outline"></ion-icon>
                                            </div>
                                            <img src="images/coffee-shop.jpg" alt="coffee shop" loading="lazy">
                                        </figure>
                                        <h3 class="project-title">Buy me a coffee</h3>
                                        <p class="project-category">Web development</p>
                                    </a>
                                </li>
                                <li class="project-item active" data-filter-item data-category="web development">
                                    <a href="https://github.com/Himel-032/Dragon_monstar_game" target="_blank">
                                        <figure class="project-img">
                                            <div class="project-item-icon-box">
                                                <ion-icon name="eye-outline"></ion-icon>
                                            </div>
                                            <img src="images/dragon-game.png" alt="dragon monster" loading="lazy">
                                        </figure>
                                        <h3 class="project-title">Dragon-Monster-Game</h3>
                                        <p class="project-category">Web development</p>
                                    </a>
                                </li>
                                <li class="project-item active" data-filter-item data-category="web design">
                                    <a href="https://github.com/Himel-032/Rock_paper_scissors_game" target="_blank">
                                        <figure class="project-img">
                                            <div class="project-item-icon-box">
                                                <ion-icon name="eye-outline"></ion-icon>
                                            </div>
                                            <img src="images/rock-paper-scissor.jpg" alt="rock paper scissors" loading="lazy">
                                        </figure>
                                        <h3 class="project-title">Rock-Paper-Scissors</h3>
                                        <p class="project-category">Web design</p>
                                    </a>
                                </li>
                                <li class="project-item active" data-filter-item data-category="applications">
                                    <a href="https://github.com/Himel-032/Bus-Booking-Application-Java" target="_blank">
                                        <figure class="project-img">
                                            <div class="project-item-icon-box">
                                                <ion-icon name="eye-outline"></ion-icon>
                                            </div>
                                            <img src="images/bus-book.png" alt="Book a bus" loading="lazy">
                                        </figure>
                                        <h3 class="project-title">Book a bus ticket</h3>
                                        <p class="project-category">Applications</p>
                                    </a>
                                </li>
                                <li class="project-item active" data-filter-item data-category="web design">
                                    <a href="https://github.com/Himel-032/Portfolio_02" target="_blank">
                                        <figure class="project-img">
                                            <div class="project-item-icon-box">
                                                <ion-icon name="eye-outline"></ion-icon>
                                            </div>
                                            <img src="images/portfolio.jpg" alt="Portfolio" loading="lazy">
                                        </figure>
                                        <h3 class="project-title">Portfolio</h3>
                                        <p class="project-category">Web design</p>
                                    </a>
                                </li>
                                <li class="project-item active" data-filter-item data-category="web design">
                                    <a href="https://github.com/Himel-032/Tic_Toc_Toe_Game" target="_blank">
                                        <figure class="project-img">
                                            <div class="project-item-icon-box">
                                                <ion-icon name="eye-outline"></ion-icon>
                                            </div>
                                            <img src="images/tick-tock-toe.jpg" alt="tic toc toe" loading="lazy">
                                        </figure>
                                        <h3 class="project-title">Tic-Toc-Toe</h3>
                                        <p class="project-category">Web design</p>
                                    </a>
                                </li>
                                <li class="project-item active" data-filter-item data-category="web development">
                                    <a href="https://github.com/Himel-032/Blog" target="_blank">
                                        <figure class="project-img">
                                            <div class="project-item-icon-box">
                                                <ion-icon name="eye-outline"></ion-icon>
                                            </div>
                                            <img src="images/blog.png" alt="my blog" loading="lazy">
                                        </figure>
                                        <h3 class="project-title">My blog</h3>
                                        <p class="project-category">Web development</p>
                                    </a>
                                </li>
                                <li class="project-item active" data-filter-item data-category="applications">
                                    <a href="https://github.com/Himel-032/ToDo-List" target="_blank">
                                        <figure class="project-img">
                                            <div class="project-item-icon-box">
                                                <ion-icon name="eye-outline"></ion-icon>
                                            </div>
                                            <img src="images/to-do-list.jpg" alt="to-do list" loading="lazy">
                                        </figure>
                                        <h3 class="project-title">To-do List</h3>
                                        <p class="project-category">Applications</p>
                                    </a>
                                </li>

                            </ul>
                        </section>
                    </article>

                    <!--Blog-->
                    <article class="blog" data-page="blog">
                        <header>
                            <h2 class="h2 article-title">Blog</h2>
                        </header>
                        <section class="blog-posts">
                            <ul class="blog-posts-list">
                                <li class="blog-post-item">
                                    <a href="https://himel-032.github.io/Blog/Blog_CP.html" target="_blank">
                                        <figure class="blog-banner-box">
                                            <img src="images/blog-cp.jpg" alt="Competitive Programmer" loading="lazy">
                                        </figure>
                                        <div class="blog-content">
                                            <div class="blog-meta">
                                                <p class="blog-category">Programming</p>
                                                <span class="dot"></span>
                                                <time datetime="2025-03-17">Mar 17, 2025</time>
                                            </div>
                                            <h3 class="h3 blog-item-title">Become a competitive programmer</h3>
                                            <p class="blog-text">
                                                Competitive programming is a sport where you solve algorithmic problems in a set amount of time. It requires
                                    problem-solving skills, knowledge of algorithms and data structures, and lots of practice. In this blog post, I'll guide
                                    you through the steps to become a competitive programmer.
                                            </p>
                                        </div>
                                    </a>
                                </li>
                                <li class="blog-post-item">
                                    <a href="https://himel-032.github.io/Blog/Blog_ML.html" target="_blank">
                                        <figure class="blog-banner-box">
                                            <img src="images/blog-ml.jpg" alt="Machine Learning" loading="lazy">
                                        </figure>
                                        <div class="blog-content">
                                            <div class="blog-meta">
                                                <p class="blog-category">Machine Learning</p>
                                                <span class="dot"></span>
                                                <time datetime="2025-03-17">Mar 17, 2025</time>
                                            </div>
                                            <h3 class="h3 blog-item-title">Machine Learning for a Beginner.</h3>
                                            <p class="blog-text">
                                                Machine learning is one of the most exciting fields in tech today. Whether you're looking to pursue a career in data
                                    science, AI, or simply curious about the technology, machine learning can be learned by anyone with the right approach.
                                    In this blog, I'll guide you through how to start your journey in learning machine learning as a beginner.
                                            </p>
                                        </div>
                                    </a>
                                </li>
                                <li class="blog-post-item">
                                    <a href="https://himel-032.github.io/Blog/Blog_web_developer.html" target="_blank">
                                        <figure class="blog-banner-box">
                                            <img src="images/blog-web-dev.jpg" alt="web development" loading="lazy">
                                        </figure>
                                        <div class="blog-content">
                                            <div class="blog-meta">
                                                <p class="blog-category">Web development</p>
                                                <span class="dot"></span>
                                                <time datetime="2025-03-17">Mar 17, 2025</time>
                                            </div>
                                            <h3 class="h3 blog-item-title">Create your Own website..</h3>
                                            <p class="blog-text">
                                                Creating your own website is easier than ever, even if you're a beginner. With the right tools and knowledge, you can
                                    have your website up and running in no time. In this blog post, I'll guide you through the basic steps involved in
                                    creating your own website.
                                            </p>
                                        </div>
                                    </a>
                                </li>
                                <li class="blog-post-item">
                                    <a href="https://himel-032.github.io/Blog/Blog_soft_dev.html" target="_blank">
                                        <figure class="blog-banner-box">
                                            <img src="images/blog-soft-dev.jpg" alt="software development" loading="lazy">
                                        </figure>
                                        <div class="blog-content">
                                            <div class="blog-meta">
                                                <p class="blog-category">Softare development</p>
                                                <span class="dot"></span>
                                                <time datetime="2025-03-17">Mar 17, 2025</time>
                                            </div>
                                            <h3 class="h3 blog-item-title">Become a software developer.</h3>
                                            <p class="blog-text">
                                                Becoming a software developer is an exciting and fulfilling career path. In this blog, I will guide you through the
                                    steps to becoming a software developer, from learning the basics to getting hands-on experience.
                                            </p>
                                        </div>
                                    </a>
                                </li>
                            </ul>
                        </section>
                    </article>
                    <!--NPM-->
                    <article class="npm" data-page="npm">
                        <header>
                            <h2 class="h2 article-title">NPM Packages
                            </h2>
                        </header>
                        <div id="packages-container">
                        <asp:Repeater ID="rptPackages" runat="server">
                            <ItemTemplate>
                                <div class="package-card">
                                    <h3>
                                        <a href='<%# Eval("npm_url") %>' target="_blank">
                                            <%# GetPackageName(Eval("npm_url")) %>
                                        </a>
                                    </h3>
                                    <p><%# GetPackageDescription(Eval("npm_url")) %></p>

                                    <pre>npm install <%# GetPackageName(Eval("npm_url")) %></pre>
                                    <a href='<%# GetGithubRepoFromNpm(Eval("npm_url")) %>' target="_blank">GitHub</a><br />
                                    <img src="https://img.shields.io/npm/v/<%# GetPackageName(Eval("npm_url")) %>?color=blue" alt="npm version" />
                                    <img src="https://img.shields.io/npm/dw/<%# GetPackageName(Eval("npm_url")) %>" alt="npm downloads" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                            </div> 

                    </article>

                    <!--contact-->
                    <article class="contact" data-page="contact">
                        <header>
                            <h2 class="h2 article-title">Contact</h2>
                        </header>
                        <section class="mapbox" data-mapbox>
                            <figure>
                                <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d29167.79873643114!2d90.20120595!3d23.96132975!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1sen!2sbd!4v1748804403739!5m2!1sen!2sbd"
                                    width="400" height="300" style="border: 0;" allowfullscreen="" loading="lazy"
                                    referrerpolicy="no-referrer-when-downgrade"></iframe>

                            </figure>
                        </section>
                        <asp:ScriptManager ID="ScriptManager1" runat="server" />
                        <section class="contact-form">
                            <h3 class="h3 form-title">Contact Form</h3>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                                    <div class="input-wrapper">

                                        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-input" Placeholder="Full name" required />
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-input" Placeholder="Email address" TextMode="Email" required />
                                    </div>
                                    <asp:TextBox ID="txtMessage" runat="server" CssClass="form-input" Placeholder="Your Message" TextMode="MultiLine" Rows="5" required />


                                    <asp:Button ID="submitBtn" runat="server" CssClass="form-btn" OnClick="submitBtn_Click" Text="╰┈➤ Send Message" />
                                    >
                              <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </section>

                    </article>

                </div>
            </main>
        </div>
    </form>

    <script src="js/script.js?v=1.0" defer></script>
    <script type="module" src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.esm.js"></script>
    <script nomodule src="https://unpkg.com/ionicons@5.5.2/dist/ionicons/ionicons.js"></script>
</body>
</html>
