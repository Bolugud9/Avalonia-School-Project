using System.Linq;
using System;
using System.Collections.Generic;
public class Words {
    
    public List<WordClass> wordClasses = new List<WordClass>();
    public Words(){
        wordClasses.Add(new WordClass("brtacy","bract","carby","carty","rybat","atry","bact","btry","carb","cray","crat","yarb","racy","aby","abr","abt","acy","arb","ary","cay","cab","ctr","art","yar","yat","rat","rya","tra","try"));
        wordClasses.Add(new WordClass("osmher","homers","herms","hoers","homes","homer","horme","horse","meros","mores","omers","sermo","shoer","smore","ersh","hers","hoer","hore","hors","home","mero","mesh","meso","mhos","more","ores","rems","resh","rheo","rhos","roes","roms","seor","sero","shmo","shoe","some","sore","her","hes","hor","hrs","mer","mho","oer","ohs","ome","ors","ose","reh","res","rhe","rho","she","sho","shr","soe"));
        wordClasses.Add(new WordClass("srcekw","wrecks","crews","recks","screw","wreck","crew","kers","reck","recs","seck","sker","skew","ckw","cre","csk","csw","erk","krs","res","sew","wer"));
        wordClasses.Add(new WordClass("bnisca","cabins","bacin","basin","cabin","cains","incas","ains","asci","banc","bani","bans","bins","cans","cabs","isba","nabs","naib","nais","nibs","sain","scab","snab","snib","abn","can","ans","asb","bin","ian","ics","ina","nib","cab","sin"));
        wordClasses.Add(new WordClass("ovuael","avoue","laevo","loave","ovule","uveal","value","aloe","eval","lave","love","leva","levo","uval","uvea","veau","velo","vole","ale","aul","lav","leu","lue","luv","ole","ule","uva","vau","vel","vol"));
        wordClasses.Add(new WordClass("tbecoj","object","objet","boce","bote","bec","job","bet","boe","cte","ecb","jct","jot","obj","ote","toe"));
        wordClasses.Add(new WordClass("yiksct","sticky","stick","ticky","ticks","cist","cyst","icky","itsy","kist","kits","scyt","sick","skit","tick","tics","csk","icy","ick","ics","yis","ist","ity","ksi","ski","sty","stk","tck","tis","tsk"));
        wordClasses.Add(new WordClass("estfad","defats","fasted","dates","defat","fades","fated","feats","fetas","sated","sedat","stade","tsade","adet","ated","atef","ates","daft","dase","date","deaf","deas","defs","deft","eats","efts","fade","fads","fate","fats","feat","feds","fest","feta","fets","safe","saft","satd","sate","seat","stad","tads","tead","teas","teds","ade","afd","ase","ast","ate","def","ead","eat","eft","est","sea","tea","tef"));
        wordClasses.Add(new WordClass("ksadam","damask","amas","asak","daks","dama","dams","kaas","kasa","kasm","maad","mads","masa","mask","dkm","dks","mas","ska"));
        wordClasses.Add(new WordClass("inedti","indite","tineid","detin","ident","idite","indie","nitid","teiid","teind","tined","deti","detn","dint","dite","edit","idin","init","inti","nide","nidi","tend","tide","tidi","tied","tind","dit","ein","end","ent","ide","ine","itd","ite","nid","nit","tie","tin"));
        wordClasses.Add(new WordClass("euyklc","yuckel","yuckle","cleuk","cyke","cyul","clue","cuke","cule","yelk","yeuk","yuck","yuke","leck","leku","leuk","cyl","cle","clk","cue","eyl","elk","kye","kyu","kue","leu","lyc","lye","luc","lue","ule"));
        wordClasses.Add(new WordClass("bleimn","milneb","nimble","benim","limen","bien","bile","bine","blin","ible","imbe","inbe","lien","limb","lime","limn","mein","mien","nimb","bin","ble","ein","elb","enl","ile","ine","lei","men","nib"));
        wordClasses.Add(new WordClass("rteahc","achter","charet","hectar","rachet","acher","arche","archt","caret","cater","cerat","chare","chart","cheat","chert","crate","creat","ecart","echar","hater","heart","rache","ratch","rathe","reach","react","recta","retch","tache","theca","ache","arch","cera","chat","crat","crea","each","eath","echt","erat","erth","etch","haec","haet","hate","hear","heat","hert","rach","rate","rath","rhet","tach","tahr","tche","tchr","tear","thae","ther","trah","aer","ate","cre","cte","ctr","ear","eat","eth","art","hae","her","het","rah","rat","reh","ret","rhe","rte","tch","tea","tha","the","tra"));
    }
}

public class WordClass{
    public string wordToFind = "Hello";
    public string[] listOfAnswers;

    public WordClass(string _wordToFind,  params String[] _listOfAnswers){
        wordToFind = _wordToFind;
        listOfAnswers = _listOfAnswers;
    }
}