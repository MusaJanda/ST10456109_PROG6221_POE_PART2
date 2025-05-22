using System;
using System.Media;
using System.IO;
using System.Collections.Generic;
using ChatBot;

namespace ChatBot
{
    class Program
    {
        // Keyword Responses: General terms where we might have a few specific points to mention.
        // Each entry should now provide *one* random response from its list.
        static Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>
        {
            { "password", new List<string> {
                "Make sure to use strong, unique passwords for each account. Avoid using personal details in your passwords.",
                "A strong password should be at least 12 characters long, including uppercase, lowercase, numbers, and symbols.",
                "Consider using a password manager to securely store and generate strong passwords."
            }},
            { "scam", new List<string> {
                "Be cautious of unsolicited communications asking for personal information or urgent action.",
                "Verify the sender's identity before responding to requests for sensitive information.",
                "If an offer seems too good to be true, it probably is. Research before engaging."
            }},
            { "privacy", new List<string> {
                "Regularly review privacy settings on your social media and other online accounts.",
                "Be mindful of what personal information you share online, as it can be used against you.",
                "Consider using privacy-focused tools like VPNs and secure browsers for enhanced protection."
            }},
            { "virus", new List<string> {
                "Keep your antivirus software updated and run regular system scans.",
                "Avoid downloading files or clicking links from untrusted sources.",
                "Be cautious when opening email attachments, even if they appear to be from known contacts."
            }},
            { "phishing", new List<string> {
                "Phishing is a deceptive tactic used by cybercriminals to trick you into revealing sensitive information.",
                "This is often done through emails, text messages, or even phone calls that impersonate legitimate organizations.",
                "The goal of phishing attacks is usually to steal your login credentials, credit card details, or other valuable data.",
                "Be cautious of unsolicited communications asking for personal information or urging you to click suspicious links."
            }},
            { "firewall", new List<string> {
                "Ensure your firewall is always enabled to protect against unauthorized network access.",
                "Configure your firewall settings to allow only necessary applications to access the internet.",
                "Both hardware and software firewalls provide important layers of security for your devices."
            }},
            { "backup", new List<string> {
                "Regularly back up important data to external drives or secure cloud services.",
                "Follow the 3-2-1 backup rule: 3 copies, 2 different media types, 1 copy offsite.",
                "Test your backups periodically to ensure data can be successfully restored."
            }},
            { "malware", new List<string> {
                "Malware is a broad term for malicious software designed to harm or exploit computer systems, networks, or users.",
                "Types include Viruses (attach to files), Worms (self-replicate), Trojans (disguise as legitimate software), Ransomware (encrypts files for ransom), and Spyware (monitors activity).",
                "Protection involves reputable antivirus, keeping software updated, caution with downloads/links, and safe Browse."
            }},
            { "encryption", new List<string> {
                "Use encryption to protect sensitive data both in transit and at rest.",
                "Enable full-disk encryption on your devices to protect data if they're lost or stolen.",
                "Look for HTTPS in your browser's address bar when visiting websites, especially when entering sensitive information."
            }},
            { "update", new List<string> {
                "Keep your operating system and applications updated to patch security vulnerabilities.",
                "Enable automatic updates when possible to ensure you're protected against known threats.",
                "Outdated software is a common entry point for cyberattacks."
            }},
            { "vpn", new List<string> {
                "A Virtual Private Network (VPN) can help protect your online privacy by encrypting your internet traffic.",
                "Use a reputable VPN service, especially when connected to public Wi-Fi networks.",
                "A VPN can mask your IP address, making it harder to track your online activity."
            }},
            { "authentication", new List<string> {
                "Enable multi-factor authentication (MFA) whenever possible for an extra layer of security.",
                "MFA typically requires a password plus a second verification method, like a code from your phone.",
                "Strong authentication methods significantly reduce the risk of unauthorized account access."
            }},
            { "social engineering", new List<string> {
                "Social engineering attacks manipulate people into divulging confidential information.",
                "Be wary of unsolicited requests for information, even if they seem to come from trusted sources.",
                "Educate yourself on common social engineering tactics like pretexting and baiting."
            }},
            { "data breach", new List<string> {
                "A data breach occurs when sensitive information is accessed or disclosed without authorization.",
                "If you suspect your data has been compromised, change your passwords immediately and monitor your accounts.",
                "Companies should have strong security measures in place to prevent data breaches and notify users promptly if one occurs."
            }},
            { "cybersecurity awareness", new List<string> {
                "Staying informed about cybersecurity threats and best practices is crucial for online safety.",
                "Regularly update your knowledge on the latest scams and attack methods.",
                "Share cybersecurity tips with friends and family to help protect them as well."
            }},
            { "ransomware", new List<string> {
                "Ransomware is a type of malware that encrypts your files and demands a ransom for their release.",
                "Avoid opening suspicious attachments or clicking on unknown links to prevent ransomware infections.",
                "Regular backups are essential for recovering from a ransomware attack without paying the ransom."
            }},
            { "spyware", new List<string> {
                "Spyware secretly monitors your computer activity and collects personal information.",
                "Be cautious about installing software from untrusted sources, as it may contain spyware.",
                "Use anti-spyware tools to detect and remove malicious software from your system."
            }},
            { "adware", new List<string> {
                "Adware displays unwanted advertisements on your computer or browser.",
                "While often less harmful than other malware, adware can be intrusive and slow down your system.",
                "Be careful when installing free software to avoid accidentally installing bundled adware."
            }},
            { "keylogger", new List<string> {
                "A keylogger records your keystrokes, potentially capturing sensitive information like passwords and credit card numbers.",
                "Be wary of installing software from unknown sources and use anti-malware software to detect keyloggers.",
                "Avoid entering sensitive information on untrusted devices or websites."
            }},
            { "dos attack", new List<string> {
                "A Denial of Service (DoS) attack attempts to make a computer or network resource unavailable to its intended users.",
                "DoS attacks often involve flooding the target with excessive traffic.",
                "Distributed Denial of Service (DDoS) attacks use multiple compromised systems to launch the attack, making them harder to block."
            }},
            { "cyber attack", new List<string> {
                "A cyberattack is a deliberate attempt to gain unauthorized access to a system, network, or device.",
                "It aims to disrupt operations, steal data, or cause other harm. Common types include Phishing, Malware, DoS/DDoS, SQL Injection, MitM attacks, and Brute-Force attacks.",
                "Staying informed and implementing security best practices is crucial for prevention."
            }},

            { "brute force", new List<string>() { // Added "brute force" here
                "A brute-force attack is a method used by attackers to try every possible combination of characters to guess a password or encryption key.",
                "These attacks can be automated and are more effective against weak or short passwords.",
                " защититься от brute-force атак можно с помощью использования длинных и сложных паролей, многофакторной аутентификации и ограничения количества попыток входа.", //russian
                "To protect against brute-force attacks, use strong, complex passwords, multi-factor authentication, and limit login attempts."
            }}
        };

        // Topic Responses: More specific, multi-line "tips" or "guides" that might be triggered by a specific phrasing.
        // Each entry should also provide *one* random response from its list.
        static Dictionary<string, List<string>> topicResponses = new Dictionary<string, List<string>>()
        {
            {"phishing tip", new List<string>() {
                "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
                "Never click on suspicious links in emails or messages. Verify the source independently by going directly to the website or contacting the company through a known number.",
                "Pay attention to the sender's email address. Look for unusual spellings, extra characters, or a domain name that doesn't match the legitimate organization.",
                "Be wary of urgent requests for immediate action or payment. Phishing emails often try to create a sense of panic.",
                "If you receive a suspicious email, don't reply to it. Instead, forward it to the organization's official anti-phishing email address (if they have one) or delete it."
            }},
            {"password tips", new List<string>() {
                "Use a unique password for each of your important accounts to prevent a compromise of one account from affecting others.",
                "Aim for passwords that are at least 12 characters long and include a mix of uppercase and lowercase letters, numbers, and special symbols for complexity.",
                "Consider using a passphrase – a sentence of random words – and then adding numbers and symbols for extra strength and memorability.",
                "Change your passwords immediately if there's any suspicion of a security breach or if you receive notifications of unusual activity.",
                "Utilize a password manager to securely generate, store, and manage complex passwords, reducing the need to remember multiple strong passwords."
            }},
            {"online safety", new List<string>() {
                "Be cautious about what personal information you share online, especially on social media platforms where privacy settings can be complex.",
                "Enable two-factor authentication (2FA) on all accounts that support it to add an extra layer of security beyond just your password.",
                "Regularly review the privacy settings of your social media accounts and other online services to control who can see your information.",
                "Be skeptical of free public Wi-Fi networks and consider using a Virtual Private Network (VPN) to encrypt your connection and protect your data.",
                "Always log out of your online accounts, especially when using shared or public computers, to prevent unauthorized access."
            }},
            {"scam alert", new List<string>() {
                "Be wary of unsolicited emails, calls, or messages asking for personal or financial information.",
                "Never click on links or open attachments from unknown or suspicious sources.",
                "If an offer sounds too good to be true, it likely is a scam.",
                "Don't feel pressured to act immediately. Scammers often create a sense of urgency.",
                "Verify requests through official channels before providing any information."
            }},
            {"privacy advice", new List<string>() {
                "Review and adjust the privacy settings on your social media and online accounts regularly.",
                "Be mindful of the personal information you share online; once it's out there, it can be hard to retract.",
                "Consider using privacy-enhancing browser extensions and tools.",
                "Be cautious of location tracking and disable it when not needed.",
                "Read privacy policies to understand how your data is being collected and used."
            }},
            {"virus protection", new List<string>() {
                "Keep your antivirus software up-to-date and run regular scans.",
                "Avoid downloading files from untrusted websites or clicking on suspicious links.",
                "Be cautious when opening email attachments, even from known senders.",
                "Enable real-time protection in your antivirus software.",
                "Consider using a firewall in addition to antivirus software for comprehensive protection."
            }},
            {"phishing awareness", new List<string>() {
                "Be suspicious of emails or messages that ask for sensitive information like passwords or credit card details.",
                "Check the sender's email address carefully for any inconsistencies or misspellings.",
                "Hover over links before clicking to see the actual URL; if it looks suspicious, don't click.",
                "Never enter your login credentials on a website linked from a suspicious email.",
                "If you're unsure about the legitimacy of a request, contact the organization directly through a known official channel."
            }},
            {"firewall tips", new List<string>() {
                "Ensure your firewall is enabled and properly configured.",
                "Allow only necessary programs and ports through your firewall.",
                "Keep your firewall software updated.",
                "Understand your firewall logs to identify potential threats.",
                "Consider using both a hardware firewall (router) and a software firewall on your computer."
            }},
            {"backup strategy", new List<string>() {
                "Regularly back up your important data.",
                "Follow the 3-2-1 rule: 3 copies, 2 different media, 1 offsite.",
                "Test your backups periodically to ensure they are working.",
                "Consider using both local and cloud-based backup solutions.",
                "Encrypt your backups to protect sensitive information."
            }},
            {"malware prevention", new List<string>() {
                "Install and keep a reputable anti-malware program updated.",
                "Be cautious about downloading software from unknown sources.",
                "Avoid clicking on suspicious ads or pop-ups.",
                "Keep your operating system and other software up to date with security patches.",
                "Be wary of USB drives and other external media from unknown sources."
            }},
            {"encryption guide", new List<string>() {
                "Use HTTPS for secure Browse (look for the padlock icon).",
                "Consider using full-disk encryption on your devices.",
                "Use strong encryption for sensitive emails and file storage.",
                "Understand the different types of encryption and when to use them.",
                "Ensure that the encryption methods you use are up to current security standards."
            }},
            {"software update advice", new List<string>() {
                "Enable automatic updates for your operating system and applications.",
                "Don't ignore update notifications; install them promptly.",
                "Be aware of end-of-life software that no longer receives security updates.",
                "Verify the legitimacy of software updates before installing them.",
                "Consider updating your web browser regularly as it's a common entry point for attacks."
            }},
            {"vpn usage", new List<string>() {
                "Use a VPN when connected to public Wi-Fi networks.",
                "Choose a reputable VPN provider with a strong privacy policy.",
                "Ensure your VPN is active before Browse sensitive websites.",
                "Understand the VPN's logging policy.",
                "Consider using a VPN even on your home network for added privacy."
            }},
            {"authentication best practices", new List<string>() {
                "Enable multi-factor authentication (MFA) whenever possible.",
                "Use strong, unique passwords for all your accounts.",
                "Be wary of remembering your passwords on public computers.",
                "Consider using biometric authentication where available.",
                "Keep your recovery codes for MFA in a safe place."
            }},
            {"social engineering defense", new List<string>() {
                "Social engineering attacks manipulate people into divulging confidential information.",
                "Be wary of unsolicited requests for information, even if they seem to come from trusted sources.",
                "Educate yourself on common social engineering tactics like pretexting and baiting."
            }},
            {"data breach response", new List<string>() {
                "A data breach occurs when sensitive information is accessed or disclosed without authorization.",
                "If you suspect your data has been compromised, change your passwords immediately and monitor your accounts.",
                "Enable fraud alerts or credit freezes if your information may be compromised.",
                "Be cautious of follow-up scams related to the breach.",
                "Follow the guidance provided by the affected organization."
            }},
            {"cybersecurity awareness tips", new List<string>() {
                "Stay informed about the latest cybersecurity threats and trends.",
                "Educate yourself and others on basic cybersecurity principles.",
                "Be mindful of your digital footprint.",
                "Regularly review and adjust your security practices.",
                "Think before you click on links or share information online."
            }},
            {"ransomware prevention", new List<string>() {
                "Be cautious of suspicious emails and attachments.",
                "Keep your operating system and software updated.",
                "Install and maintain reputable anti-malware software.",
                "Regularly back up your important data offline.",
                "Educate yourself on how ransomware attacks occur."
            }},
            {"spyware removal", new List<string>() {
                "Install and run a reputable anti-spyware program.",
                "Be cautious about installing software from untrusted sources.",
                "Keep your operating system and browser updated.",
                "Review your installed programs for anything suspicious.",
                "Consider a clean reinstall of your operating system if you suspect a severe infection."
            }},
            {"adware removal", new List<string>() {
                "Be careful when installing free software and uncheck any unwanted bundled programs.",
                "Use a reputable anti-malware program that can detect and remove adware.",
                "Consider using browser extensions that block ads.",
                "Review your browser's extensions and remove any you don't recognize.",
                "Be cautious of clicking on intrusive ads or pop-ups."
            }},
            {"keylogger detection", new List<string>() {
                "A keylogger records your keystrokes, potentially capturing sensitive information like passwords and credit card numbers.",
                "Be wary of installing software from unknown sources and use anti-malware software to detect keyloggers.",
                "Avoid entering sensitive information on untrusted devices or websites."
            }},
            {"dos attack mitigation (user)", new List<string>() {
                "Ensure your own devices and network are secure and up-to-date.",
                "Use a strong firewall and keep your router firmware updated.",
                "Be cautious about clicking suspicious links to prevent becoming part of a botnet.",
                "If your personal internet connection is affected, contact your ISP.",
                "Understand that as an individual, directly stopping a large-scale DoS attack is usually not possible."
            }}
        };

        // Sentiment Responses: Map sentiment keywords to empathetic responses
        static Dictionary<string, List<string>> sentimentResponses = new Dictionary<string, List<string>>()
        {
            { "worried", new List<string>() {
                "It's completely understandable to feel that way.",
                "I hear your concern. It's normal to feel worried about these things."
            }},
            { "frustrated", new List<string>() {
                "I can see why that would be frustrating.",
                "It sounds like you're feeling frustrated. Let's see if I can help clarify things."
            }},
            { "curious", new List<string>() {
                "That's a great question to be curious about!",
                "I appreciate your curiosity. It's a good way to learn and stay safe."
            }},
            { "confused", new List<string>() {
                "I understand this can be a bit confusing. I'll do my best to explain clearly.",
                "It's okay to be confused; cybersecurity can be complex. Let's break it down."
            }},
            { "overwhelmed", new List<string>() {
                "It sounds like you're feeling a bit overwhelmed, and that's perfectly normal.",
                "Cybersecurity can be a lot to take in. We can go at your own pace."
            }},
            { "unsure", new List<string>() {
                "It's wise to be unsure when dealing with cybersecurity. Let's explore it together.",
                "I'm here to help clarify any uncertainties you have."
            }}
        };


        static Random random = new Random();
        static string currentTopic = null; // To track the current conversation topic
        static Dictionary<string, string> userMemory = new Dictionary<string, string>(); // For memory and recall


        static void Main(string[] args)
        {
            // --- 🔊 1. Voice Greeting ---
            try
            {
                AudioPlayer audioPlayer = new AudioPlayer();
                audioPlayer.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing voice greeting: {ex.Message}");
            }

            // --- 🖼️ 2. Image Display (ASCII Art from User Input) ---
            string logo = @"
 ____     _          ____                   _ _
/ ___|   _| |__  ___ _ __/ ___| ___  ___ _  _ _ __(_) |_ _  _
| |     | | '_ \/ _ \ '__\___ \/ _ \/ __| | | | '__| | __| | |
| |___  |_| |_) |  __/ |  ___) |  __/ (__| |_| | |  | | |_| |_|
\____\__, |_.__/ \___|_| |____/ \___|\___|\__,_|_|  |_|\__|\__, |
 ____|___/      _   ____     _                           |___/
/ ___| |__  __ _| |_| __ ) ___ | |_
| |    | '_ \/ _` | __| _ \ / _ \| __|
| |___ | | | | (_| | |_| |_) | (_) | |_
\____|_| |_|\__,_|\__|____/ \___/ \__|
";
            // Split into lines
            string[] lines = logo.Split('\n');


            // Display the logo at the top-left corner
            foreach (string line in lines)
            {
                Console.WriteLine(line); // No padding, so it starts from the left
            }
            Console.WriteLine(); // Add an empty line for spacing

            // Image instance to display an image
            ImageDisplay display = new ImageDisplay();
            display.Show();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("+-----------------------------+");
            Console.WriteLine("|     Let's stay cyber safe! |");
            Console.WriteLine("+-----------------------------+");
            Console.WriteLine();

            // --- 🧑‍💻 3. Text-Based Greeting and User Interaction ---
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Bot: What is your name? ");
            Console.WriteLine();
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("You: ");
            string name = Console.ReadLine();
            Console.ResetColor();

            // Store the user's name, defaulting to "Guest" if empty
            string userName = string.IsNullOrWhiteSpace(name) ? "Guest" : name;
            userMemory["name"] = userName;


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\nWelcome, {userName}! Great to have you here.");
            Console.ResetColor();


            // --- 💬 4. Basic Interaction System ---
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("You: ");
                string question = Console.ReadLine()?.ToLower().Trim();
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(question))
                {
                    DisplayBotMessage("Please enter a question.");
                    continue;
                }

                // --- Sentiment Detection Logic ---
                string detectedSentiment = DetectSentiment(question);
                if (detectedSentiment != null)
                {
                    DisplayEmpatheticResponse(detectedSentiment);
                }

                if (question.Contains("exit") || question.Contains("thank you") || question.Contains("amen"))
                {
                    DisplayBotMessage($"You're welcome, {userMemory.GetValueOrDefault("name", "Guest")}! Stay safe online!");
                    currentTopic = null; // Clear topic on exit
                    break;
                }
                else if (question.Contains("how are you"))
                {
                    DisplayBotMessage("As a digital entity, I don't experience emotions in the same way humans do. However, I am functioning optimally and ready to assist you with your cybersecurity inquiries. My systems are running smoothly, and I'm here to provide you with the information you need to stay safe online.");
                }
                else if (question.Contains("what can i ask you"))
                {
                    DisplayBotMessage("Ask me anything regarding Cybersecurity!");
                }
                else if (question.Contains("purpose"))
                {
                    DisplayBotMessage("My purpose is to educate you on the fundamental principles of cybersecurity and online safety. I aim to provide clear and concise information to help you understand common threats and learn practical steps to protect yourself in the digital world. Think of me as your friendly guide to staying safe online.");
                }
                else
                {
                    bool foundResponse = false;

                    // Check for general follow-up phrases that imply "tell me more about the last thing"
                    bool isFollowUpQuestion = question.Contains("more details") ||
                                              question.Contains("tell me more") ||
                                              question.Contains("what about that") ||
                                              question.Contains("elaborate") ||
                                              question.Contains("continue");


                    if (isFollowUpQuestion && currentTopic != null)
                    {
                        // Try to find more details from topicResponses first
                        if (topicResponses.ContainsKey(currentTopic))
                        {
                            int index = random.Next(topicResponses[currentTopic].Count);
                            DisplayBotMessage($"Regarding {currentTopic}, here's another detail: {topicResponses[currentTopic][index]}");
                            foundResponse = true;
                        }
                        // If currentTopic isn't in topicResponses but is in keywordResponses
                        else if (keywordResponses.ContainsKey(currentTopic))
                        {
                            int index = random.Next(keywordResponses[currentTopic].Count);
                            DisplayBotMessage($"About {currentTopic}, here's another point: {keywordResponses[currentTopic][index]}");
                            foundResponse = true;
                        }
                        // If currentTopic is set but no specific further details are available in either of the above
                        if (!foundResponse) // This condition will be true if currentTopic was set, but no *additional* specific responses were found for it
                        {
                            DisplayBotMessage($"You asked about '{currentTopic}'. What specific aspect are you interested in or would you like me to tell you more about?");
                            foundResponse = true; // Still counts as handled even if it's a generic follow-up
                        }
                    }

                    // If not a general follow-up, or if a follow-up was handled and no more specific responses were found for currentTopic
                    if (!foundResponse) // Re-check foundResponse to ensure we don't fall through if a follow-up was handled
                    {
                        // Prioritize specific 'topic' tips if a direct match is found
                        foreach (var topicPair in topicResponses)
                        {
                            if (question.Contains(topicPair.Key))
                            {
                                int index = random.Next(topicPair.Value.Count);
                                DisplayBotMessage(topicPair.Value[index]);
                                currentTopic = topicPair.Key; // Set current topic for potential follow-up
                                foundResponse = true;
                                break;
                            }
                        }
                    }

                    // If still no response found (meaning no topic match and not a handled follow-up)
                    if (!foundResponse)
                    {
                        // Now check general keyword responses
                        foreach (var keywordPair in keywordResponses)
                        {
                            if (question.Contains(keywordPair.Key))
                            {
                                int index = random.Next(keywordPair.Value.Count);
                                DisplayBotMessage(keywordPair.Value[index]);
                                currentTopic = keywordPair.Key; // <--- ADD THIS LINE TO SET currentTopic FOR KEYWORD RESPONSES
                                foundResponse = true;
                                break;
                            }
                        }
                    }

                    // If still no response after all checks
                    if (!foundResponse && detectedSentiment == null) // Ensure we don't override sentiment responses
                    {
                        DisplayBotMessage("I'm sorry, I don't have information on that specific topic at the moment. Please try asking about a different cybersecurity term or concept. For example, you can ask about 'passwords', 'phishing', 'malware', or 'VPNs'.");
                        currentTopic = null; // Clear topic if no specific information is found
                    }
                }
            }
        }

        // Helper method to display bot messages
        static void DisplayBotMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Bot: {message}");
            Console.ResetColor();
        }

        // Helper method to detect sentiment
        static string DetectSentiment(string question)
        {
            foreach (var sentimentPair in sentimentResponses)
            {
                if (question.Contains(sentimentPair.Key))
                {
                    return sentimentPair.Key;
                }
            }
            return null;
        }

        // Helper method to display empathetic response
        static void DisplayEmpatheticResponse(string sentiment)
        {
            if (sentimentResponses.ContainsKey(sentiment))
            {
                int index = random.Next(sentimentResponses[sentiment].Count);
                DisplayBotMessage(sentimentResponses[sentiment][index]);
            }
        }
    }
}