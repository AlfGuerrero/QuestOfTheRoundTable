﻿using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Logger provided by: 
 * Lachlan Campbell Student Carleton University (COMP3004)
 * C#Logger for Unity
 * Provided by Tuesday, 13 February 2018, 11:43 AM
 * Written in C#
*/
namespace QuestGame {
	public class Logger : MonoBehaviour{

		//This constructor will call the init function
		//Should only be called once in your code
		public Logger() {
			this.init();
		}

		//Can be called as many time as you want in your code (as it will still construct the logger but won't call the init function
		public Logger(bool b) {} //This constructor won't call the init function

		public void logCustom(string n, string type) {
			printToFile(generateTimestamp() + " [" + type.ToUpper() + "]: " + n + "\n");
		}

		public void info(string n) {
			printToFile(generateTimestamp() + " [INFO]: " + n + "\n");
		}

		public void debug(string n) {
			printToFile(generateTimestamp() + " [DEBUG]: " + n + "\n");
		}

		public void warn(string n) {
			printToFile(generateTimestamp() + " [WARN]: " + n + "\n");
		}

		public void error(string n) {
			printToFile(generateTimestamp() + " [ERROR]: " + n + "\n");
		}

		public void trace(string n) {
			printToFile(generateTimestamp() + " [TRACE]: " + n + "\n");
		}

		public void test(string n) {
			printToFile(generateTimestamp() + " [TEST]: " + n + "\n");
		}
	
		private void init() {
//			printToFile("-------------------- INITIALIZE LOGGER ---------------------\n");
//			printToFile(generateTimestamp() + ": Logger initialized\n");
		}

		private void printToFile(string n) {
			System.IO.File.AppendAllText(Directory.GetCurrentDirectory() + "/Logs/EventLog.txt", n);
		}

		private string generateTimestamp() {
			return DateTime.Now.ToString("O");
		}
	}
}