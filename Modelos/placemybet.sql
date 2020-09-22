-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 22-09-2020 a las 22:05:59
-- Versión del servidor: 10.4.11-MariaDB
-- Versión de PHP: 7.4.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `placemybet`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `apuesta`
--

CREATE TABLE `apuesta` (
  `id` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `cuota` double NOT NULL,
  `tipo_apuesta` varchar(10) NOT NULL,
  `dinero_apostado` double NOT NULL,
  `id_mercado` int(11) NOT NULL,
  `email_usuario` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `apuesta`
--

INSERT INTO `apuesta` (`id`, `fecha`, `cuota`, `tipo_apuesta`, `dinero_apostado`, `id_mercado`, `email_usuario`) VALUES
(1, '2020-04-08', 1.43, 'over', 50, 1, 'ejemplo@ejemplo.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuenta_bancaria`
--

CREATE TABLE `cuenta_bancaria` (
  `id` int(11) NOT NULL,
  `nombre_banco` varchar(100) NOT NULL,
  `num_tarjeta` bigint(16) NOT NULL,
  `saldo` double NOT NULL,
  `email_usuario` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `cuenta_bancaria`
--

INSERT INTO `cuenta_bancaria` (`id`, `nombre_banco`, `num_tarjeta`, `saldo`, `email_usuario`) VALUES
(1, 'Santander', 9223372036854775807, 500, 'ejemplo@ejemplo.com');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `evento`
--

CREATE TABLE `evento` (
  `id` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `equipo_local` varchar(100) NOT NULL,
  `equipo_visitante` varchar(100) NOT NULL,
  `goles_totales` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `evento`
--

INSERT INTO `evento` (`id`, `fecha`, `equipo_local`, `equipo_visitante`, `goles_totales`) VALUES
(1, '2020-04-08', 'Valencia', 'Barcelona', 5);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mercado`
--

CREATE TABLE `mercado` (
  `id` int(11) NOT NULL,
  `over/under` double NOT NULL,
  `cuota_over` double NOT NULL,
  `cuota_under` double NOT NULL,
  `apostado_over` double NOT NULL,
  `apostado_under` double NOT NULL,
  `id_evento` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `mercado`
--

INSERT INTO `mercado` (`id`, `over/under`, `cuota_over`, `cuota_under`, `apostado_over`, `apostado_under`, `id_evento`) VALUES
(1, 1.5, 1.43, 1.9, 100, 200, 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `usuario`
--

CREATE TABLE `usuario` (
  `email` varchar(100) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `apellidos` varchar(100) NOT NULL,
  `edad` int(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `usuario`
--

INSERT INTO `usuario` (`email`, `nombre`, `apellidos`, `edad`) VALUES
('ejemplo@ejemplo.com', 'Ricardo', 'Lucas Asins', 55);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `apuesta`
--
ALTER TABLE `apuesta`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_id_mercado` (`id_mercado`),
  ADD KEY `FK_email_usuario` (`email_usuario`);

--
-- Indices de la tabla `cuenta_bancaria`
--
ALTER TABLE `cuenta_bancaria`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `FK_email_usuario` (`email_usuario`) USING BTREE;

--
-- Indices de la tabla `evento`
--
ALTER TABLE `evento`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `mercado`
--
ALTER TABLE `mercado`
  ADD PRIMARY KEY (`id`),
  ADD KEY `FK_id_evento` (`id_evento`);

--
-- Indices de la tabla `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`email`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `apuesta`
--
ALTER TABLE `apuesta`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `cuenta_bancaria`
--
ALTER TABLE `cuenta_bancaria`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de la tabla `evento`
--
ALTER TABLE `evento`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `mercado`
--
ALTER TABLE `mercado`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `apuesta`
--
ALTER TABLE `apuesta`
  ADD CONSTRAINT `apuesta_ibfk_1` FOREIGN KEY (`id_mercado`) REFERENCES `mercado` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `apuesta_ibfk_2` FOREIGN KEY (`email_usuario`) REFERENCES `usuario` (`email`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `cuenta_bancaria`
--
ALTER TABLE `cuenta_bancaria`
  ADD CONSTRAINT `cuenta_bancaria_ibfk_1` FOREIGN KEY (`email_usuario`) REFERENCES `usuario` (`email`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Filtros para la tabla `mercado`
--
ALTER TABLE `mercado`
  ADD CONSTRAINT `mercado_ibfk_1` FOREIGN KEY (`id_evento`) REFERENCES `evento` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
