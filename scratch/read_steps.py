import json

transcript_path = r'C:\Users\usuario\.gemini\antigravity\brain\6d6f5d5a-4cad-4d65-af9e-bdf70f4db580\.system_generated\logs\transcript.jsonl'
with open(transcript_path, 'r', encoding='utf-8') as f:
    for line in f:
        data = json.loads(line)
        idx = data.get('step_index')
        if idx in [2142, 2143, 2144, 2145, 2146, 2147, 2148, 2149, 2150]:
            print(f"=== STEP {idx} ({data.get('type')}) ===")
            content = data.get('content', '')
            if content:
                print(content[:1500])
                if len(content) > 1500:
                    print("... [TRUNCATED]")
