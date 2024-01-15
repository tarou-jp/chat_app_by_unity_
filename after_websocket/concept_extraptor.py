# 以下のソースコードを引用　https://github.com/dsbook/dsbook/blob/master/da_extractor.py
import MeCab
from sklearn.feature_extraction.text import TfidfVectorizer
from sklearn.svm import SVC
from sklearn.preprocessing import LabelEncoder
import dill
import sys

mecab = MeCab.Tagger()
mecab.parse('')

# SVMモデルの読み込み
with open("svc.model","rb") as f:
    vectorizer = dill.load(f)
    label_encoder = dill.load(f)
    svc = dill.load(f)
   
def extract_da(utt):
    words = []
    for line in mecab.parse(utt).splitlines():
        if line == "EOS":
            break
        else:
            word, feature_str = line.split("\t")
            words.append(word)
    tokens_str = " ".join(words)
    X = vectorizer.transform([tokens_str])
    Y = svc.predict(X)
    da = label_encoder.inverse_transform(Y)[0]
    return da

# text = input("話しかけよう")
# text = str(sys.argv[1])
# print(text,extract_da(text))
# print(extract_da(text))
        
